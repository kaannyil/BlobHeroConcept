using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        SpiralFormation();
    }

    private void SpiralFormation()
    {
        Vector3 targetPosition = /*Vector3.zero*/ transform.position;

        GameObject container = new GameObject("Container");
        container.transform.position = Vector3.zero;

        for (int i = 0; i < 4; i++)
        {
            GameObject instance = Instantiate(prefab);

            // float angle = i * (2 * 3.14159f / 20);

            float angle = i * (2 * 3.14159f / 4);

            float x = Mathf.Cos(angle) * 2f;
            float z = Mathf.Sin(angle) * 2f;

            targetPosition = new Vector3(targetPosition.x + x, 1, targetPosition.z + z);

            instance.transform.position = targetPosition;

            instance.transform.SetParent(container.transform);
        }
    }
}
