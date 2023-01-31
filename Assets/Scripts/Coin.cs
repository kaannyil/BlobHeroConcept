using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [HideInInspector] public Transform playerTransform;
    public float moveSpeed;
    CoinMove coinMoveScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Bir objeyi referans göstermeden direkt baðlamanýn yolu
        coinMoveScript = GetComponent<CoinMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CoinDetector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
