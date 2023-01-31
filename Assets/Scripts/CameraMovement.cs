using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // public Transform target;
    public Vector3 offset;
    public float lerpValue;

    private void LateUpdate()
    {
        Vector3 desPos = PlayerController.instance.gameObject.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, desPos, lerpValue);
    }
}
