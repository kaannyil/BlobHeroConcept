using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpPanelController : MonoBehaviour
{
    public static ExpPanelController instance;

    [SerializeField] public Slider slider;
    [SerializeField] private TextMeshProUGUI LevelTMP;
    [SerializeField] private ParticleSystem levelUpParticle;

    private int level = 1;
    public int levelCounter;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {   
        slider.value = 0;
        LevelTMP.text = "Level 1";
    }

    private void Update()
    {
        if (slider.value >= slider.maxValue)
        {
            slider.value = 0;
            slider.maxValue += (int)(slider.maxValue * 25 / 100);

            levelUpParticle.Play();
            level += 1;
            levelCounter += 1;
            LevelTMP.text = "Level " + level;

            if (PlayerController.instance.currentHealth + ((PlayerController.instance.maxHealth * 10) / 100) > PlayerController.instance.maxHealth)
            {
                PlayerController.instance.currentHealth = PlayerController.instance.maxHealth;
            }
            else PlayerController.instance.currentHealth += (PlayerController.instance.maxHealth * 10) / 100;

            StartCoroutine(LevelUpCoroutine());
        }
    }   
    IEnumerator LevelUpCoroutine()
    {
        yield return new WaitForSeconds(1f);

        FirstPanelController.instance.randomSkillChoice();
        ButtonController.instance.firstSkillPanel.SetActive(true);

        /*for (int i = 0; i < levelCounter; levelCounter--)
        {

            Debug.Log(levelCounter);
            FirstPanelController.instance.randomSkillChoice();
            ButtonController.instance.firstSkillPanel.SetActive(true);
        }*/

    }
}
