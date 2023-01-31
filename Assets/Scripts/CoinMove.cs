using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [Tooltip("Kaç Exp kazanacaðýmýzý belirliyoruz.")]
    [SerializeField] private float sliderValue;
    Coin coinScript;
    void Start()
    {
        coinScript = GetComponent<Coin>();        
    }
    void Update()
    {
        Vector3 playerNewTransform = coinScript.playerTransform.position;
        playerNewTransform.y += .5f;

        transform.position = Vector3.MoveTowards(transform.position, playerNewTransform, coinScript.moveSpeed * Time.deltaTime); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 1)
        {
            Destroy(gameObject);

            ExpPanelController.instance.slider.value += sliderValue;

            Debug.Log("Diamond alýndý.");
        }
    }
}
