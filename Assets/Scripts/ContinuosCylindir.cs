using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuosCylindir : MonoBehaviour
{
    public static ContinuosCylindir instance;

    public float newRadiusValue, currentRadiusValue, newDamage, currentDamage, counterRadius, counterDamage;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        counterRadius = (currentRadiusValue / 100) * 10;
    }
    private void Update()
    {
        // cylendirRadius();
    }

    public void cylendirRadiusAndDamage()
    {
        /* if (Input.GetKeyDown(KeyCode.Z))
         {
             newRadiusValue += counter;
             transform.localScale = new Vector3(newRadiusValue, this.transform.localScale.y, newRadiusValue);
         }*/

        counterDamage = (currentDamage / 100) * 10;

        newDamage += counterDamage;
        newRadiusValue += counterRadius;
        currentDamage = newDamage;
        currentRadiusValue = newRadiusValue;

        transform.localScale = new Vector3(newRadiusValue, this.transform.localScale.y, newRadiusValue);
    }
}
