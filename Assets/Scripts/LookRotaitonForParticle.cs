using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotaitonForParticle : MonoBehaviour
{
    [SerializeField] private Transform followCamera;
    void Update()
    {
        Vector3 targetPosition = new Vector3(followCamera.position.x, followCamera.position.y, this.transform.position.z);
        this.transform.LookAt(targetPosition);
    }
}
