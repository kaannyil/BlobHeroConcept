using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NearlyShootMovement : MonoBehaviour
{
    public static NearlyShootMovement instance;

    [SerializeField] private RunEnemyController runEnemyController;
    [SerializeField] private NearlyShootCreate nearlyShootCreate;
    [SerializeField] private float moveSpeed,turnSpeed;
    // [SerializeField] private ParticleSystem boomEfect;

    float tempObjectDistance, keepObjectDistance;
    private bool radiusControl = true;

    public SphereCollider sphereCollider;

    [SerializeField] private Rigidbody rb;

    private Quaternion rotationGoal;
    
    GameObject keepObject;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        rb.GetComponent<Rigidbody>();
        sphereCollider.GetComponent<SphereCollider>();

        for (int i = 0; i < ObjectPool.instance.enemyList.Count; i++)
        {
            tempObjectDistance = Vector3.Distance(PlayerController.instance.transform.position, ObjectPool.instance.enemyList[i].transform.position);

            if (keepObject == null && ObjectPool.instance.enemyList[i].activeSelf)
            {
                keepObjectDistance = tempObjectDistance;

                keepObject = ObjectPool.instance.enemyList[i];
            }

            else if (ObjectPool.instance.enemyList[i].activeSelf)
            {
                if (tempObjectDistance < keepObjectDistance)
                {
                    keepObjectDistance = tempObjectDistance;

                    keepObject = ObjectPool.instance.enemyList[i];
                }
            }
        }
        moveEnemyDo();
    }

    /*void Update()
    {
        if (keepObject == null || keepObject.activeSelf==false) Destroy(this.gameObject);
        else
        {
            Vector3 direction = (keepObject.transform.position - transform.position).normalized;
            rotationGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed); // Smooth change rotation

            moveEnemy(direction);
        }
    }

    private void moveEnemy(Vector3 direction)   // Enemy straight move by rotation 
    {
        rb.MovePosition(transform.position + (*//*transform.forward*//* direction * moveSpeed * Time.deltaTime));
    }*/
    private void moveEnemyDo()
    {
        Vector3 direction = (keepObject.transform.position - transform.position);
        Vector3 keepObjectTransform = keepObject.transform.position;
        keepObjectTransform.y += 1;

        transform.DOMove(keepObjectTransform, moveSpeed).SetSpeedBased(true).SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            Destroy(this.gameObject);
        });

        transform.DOLookAt(keepObjectTransform, .2f);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Enemy") && radiusControl == true)
        {
            radiusControl = false;
            /*Instantiate(boomEfect, transform.position, transform.rotation);
            Destroy(boomEfect, 1f);*/

            sphereCollider.radius = NearlyShootCreate.instance.radiusValue;
            StartCoroutine(radiusSecond());
        }
    }
    IEnumerator radiusSecond()
    {
        yield return new WaitForSeconds(.02f);
        Destroy(this.gameObject);
    }
}
