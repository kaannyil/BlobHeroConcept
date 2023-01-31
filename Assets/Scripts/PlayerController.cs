using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] SkillsActivatedFalse;
    [SerializeField] private GameObject gameOverPanel, continuePanel;

    [SerializeField] private float moveSpeed;
    [SerializeField] public float currentHealth, maxHealth;

    [HideInInspector] public bool levelEndBool = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if (currentHealth > 0)
        {
            rigidBody.velocity = new Vector3(joystick.Horizontal * moveSpeed, rigidBody.velocity.y, joystick.Vertical * moveSpeed);

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
                GameOverUIController.instance.gameoverPanelFunc();
            }
        }

        else
        {
            animator.SetBool("isDying", true);
            joystick.gameObject.SetActive(false);

            for (int i = 0; i < SkillsActivatedFalse.Length; i++)
            {
                SkillsActivatedFalse[i].SetActive(false);
            }

            RunEnemyController.instance.isTrigger = false;

            rigidBody.velocity = Vector3.zero;

            StartCoroutine(gameOverEnumerator());
            return;
        }
    }

    private void Update()
    {
        healthBar.updateHealthBar(maxHealth, currentHealth);

        if (levelEndBool == true)
        {
            StartCoroutine(levelEndEnumerator());
        }
    }
    IEnumerator gameOverEnumerator()
    {
        yield return new WaitForSeconds(2f);

        gameOverPanel.SetActive(true);
    }

    IEnumerator levelEndEnumerator()
    {
        levelEndBool = false;
        yield return new WaitForSeconds(2f);

        continuePanel.SetActive(true);
    }
}
