using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetDistance : MonoBehaviour
{
    public static MagnetDistance instance;

    [SerializeField] private float currentMagnetDistance;
    [SerializeField] private SphereCollider sphereCollider;

    private void Awake()
    {
        instance = this;
    }

    public void DistanceIncrease()
    {
        sphereCollider.radius += ((sphereCollider.radius * 15) / 100);
        currentMagnetDistance = sphereCollider.radius;
    }
}
