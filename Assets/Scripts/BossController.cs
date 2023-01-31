using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BossController : MonoBehaviour
{
    public static BossController instance;

    [SerializeField] private Transform /*followTarget,*/ canvasTransform;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed, turnSpeed, attackDamage;
    [SerializeField] public float HP;
    [SerializeField] private TextMeshProUGUI damageCounterTMP;
    [SerializeField] private GameObject deadDiamond;

    [HideInInspector] public bool isTrigger = false, attackDamageBool = false;

    private float targetTime = 0.2f, damageCounter, beginHP;

    // private Vector3 movement;
    private Quaternion rotationGoal;
    private Camera cam;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        beginHP = HP;
        rb.GetComponent<Rigidbody>();
        cam = Camera.main;
        animator.SetBool("isRunning", true);
    }
    void Update()
    {
        Vector3 cameraDirection = canvasTransform.position - cam.transform.position;
        canvasTransform.rotation = Quaternion.LookRotation(cameraDirection);    // Enemy damage text lookRotation to every frame

        Vector3 direction = (PlayerController.instance.transform.position - transform.position).normalized;
        rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation

        // direction.Normalize();
        // movement = direction;

        if (HP <= 0)
        {
            gameObject.SetActive(false);
            isTrigger = false;
            attackDamageBool = false;
            damageCounterTMP.gameObject.SetActive(false);

            HP = beginHP;
            damageCounter = 0;
            damageCounterTMP.text = "";

            // ExpPanelController.instance.slider.value += 1;

            Instantiate(deadDiamond, new Vector3(transform.position.x, deadDiamond.transform.position.y, transform.position.z), deadDiamond.transform.rotation);
        }
    }

    private void OnDisable()
    {
        AudioController.instance.BossDyingAudio.Play();
        PlayerController.instance.levelEndBool = true;
    }

    private void FixedUpdate()
    {
        moveEnemy();

        if (isTrigger)  // Attack continuous cylendir every second
        {
            targetTime += 0.01f;

            if (targetTime >= 0.1f)
            {
                HP -= ContinuosCylindir.instance.currentDamage;
                damageCounter += ContinuosCylindir.instance.currentDamage;
                damageCounterTMP.text = damageCounter.ToString("0");
                targetTime = 0f;
            }
        }
        if (attackDamageBool)
        {
            PlayerController.instance.currentHealth -= attackDamage;
        }
    }   // Enemy movement, continuous damage control

    private void moveEnemy(/*Vector3 direction*/)   // Enemy straight move by rotation 
    {
        // rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
    }

    #region Triggers 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ContinuousCylindir"))  // isTrigger Cylendir
        {
            damageCounterTMP.gameObject.SetActive(true);
            isTrigger = true;
        }

        if (other.gameObject.CompareTag("TurnAround"))  // Decrease enemy heal and write damage
        {
            HP -= TurnAround.instance.currentDamage;
            damageCounter += TurnAround.instance.currentDamage;

            damageCounterTMP.gameObject.SetActive(true);
            damageCounterTMP.text = damageCounter.ToString("0");
            // damageCounterTMP.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("NearlyShoot"))
        {
            HP -= NearlyShootCreate.instance.currentDamage;
            damageCounter += NearlyShootCreate.instance.currentDamage;

            damageCounterTMP.gameObject.SetActive(true);
            damageCounterTMP.text = damageCounter.ToString("0");
            // Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))  // Player decrease heal
        {
            if (PlayerController.instance.currentHealth > 0) attackDamageBool = true;
            animator.SetBool("isRunning", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ContinuousCylindir"))  // !isTrigger Cylendir
        {
            damageCounterTMP.gameObject.SetActive(false);
            isTrigger = false;
        }

        if (other.gameObject.CompareTag("Player"))  // Player decrease heal
        {
            if (PlayerController.instance.currentHealth > 0) attackDamageBool = false;
            animator.SetBool("isRunning", true);
        }
    }
    #endregion
} 
