using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    private Transform followCamera;
    private void Start()
    {
        followCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    void Update()
    {
        /*// Vector3 cameraDirection = (followCamera.position - followObject.position);
        Vector3 cameraDirection = new Vector3(this.transform.position.x, followCamera.position.y - followObject.position.y,this.transform.position.z);
        followObject.rotation = Quaternion.LookRotation(cameraDirection);*/

        Vector3 targetPosition = new Vector3(followCamera.position.x, this.transform.position.y, followCamera.position.z);
        this.transform.LookAt(targetPosition);

    }
}
