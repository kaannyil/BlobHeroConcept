using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;

    [SerializeField] private GameObject[] UIs;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void gameoverPanelFunc()
    {
        if (PlayerController.instance.currentHealth < 0)
        {
            for (int i = 0; i < UIs.Length ; i++)
            {
                UIs[i].SetActive(false);
            }
        }
        return;
    }
}
