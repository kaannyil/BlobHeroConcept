using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 60;
    }
}
