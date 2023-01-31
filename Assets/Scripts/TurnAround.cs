using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public static TurnAround instance;

    [SerializeField] private GameObject pivotObject;


    public float rotationSpeed;
    public float currentDamage;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Update()
    {
        transform.RotateAround(pivotObject.transform.position, new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
    }

    public void damageAndRotationSpeed()
    {
        float newDamage = (currentDamage + ((currentDamage / 100) * 10));
        int newRotationSpeed = (int)(rotationSpeed + ((rotationSpeed / 100) * 10));

        currentDamage = newDamage;
        rotationSpeed = newRotationSpeed;
    }
    private void OnEnable()
    {
        EventManager.TurnAround.AddListener(damageAndRotationSpeed);
    }
    private void OnDisable()
    {
        EventManager.TurnAround.RemoveListener(damageAndRotationSpeed);
    }
}
