using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearlyShootCreate : MonoBehaviour
{
    public static NearlyShootCreate instance;

    [SerializeField] private GameObject nearlyShootObject,nearlyShootCreateObject;
    [SerializeField] private float createTime;

    private bool createShootObject = true;

    public float radiusValue, currentDamage;

    GameObject nearlyShootObjectClone;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        if (createShootObject == true) StartCoroutine(nearlyShoot());
    }

    IEnumerator nearlyShoot()
    {
        createShootObject = false;

        yield return new WaitForSeconds(createTime);

        if (ObjectPool.instance.enemyList != null)
        {
            Vector3 playerPosition = PlayerController.instance.transform.position;
            playerPosition.y += .9f;

            nearlyShootObjectClone = Instantiate(nearlyShootObject, playerPosition, Quaternion.identity);
            nearlyShootObjectClone.transform.SetParent(nearlyShootCreateObject.gameObject.transform);
            nearlyShootObjectClone.SetActive(true);
        }

        createShootObject = true;
    }

    public void updateNearlyShoot() {
        createTime -= (createTime * 10) / 100;
        radiusValue += radiusValue / 6;
        currentDamage += ((currentDamage * 10) / 100);
    }
}
