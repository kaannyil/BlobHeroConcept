using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegeneration : MonoBehaviour
{
    public static HPRegeneration instance;

    [SerializeField] private ParticleSystem regenerationAnim;
    [SerializeField] private AudioSource healingAudio;
    public float regenerationValue = 2;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        StartCoroutine(regenerationCoroutine());
    }

    IEnumerator regenerationCoroutine()
    {
        while (PlayerController.instance.currentHealth > 0)
        {
            yield return new WaitForSeconds(10f);

            regenerationAnim.Play();
            healingAudio.Play();

            if (PlayerController.instance.currentHealth + ((PlayerController.instance.maxHealth * regenerationValue) / 100) > PlayerController.instance.maxHealth)
            {
                PlayerController.instance.currentHealth = PlayerController.instance.maxHealth;
            }
            else PlayerController.instance.currentHealth += (int)(PlayerController.instance.maxHealth * regenerationValue / 100);
        }
    }
}
