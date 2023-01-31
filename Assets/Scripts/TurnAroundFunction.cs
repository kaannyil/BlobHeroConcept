using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundFunction : MonoBehaviour
{
    public static TurnAroundFunction instance;

    [SerializeField] public List<GameObject> ballsList = new List<GameObject>();

    public float turnAroundRadiusValue, newTurnAroundRadiusValue, ballScale, newBallScale, counterTurnAroundRadius, counterBall;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        counterTurnAroundRadius = (turnAroundRadiusValue / 100) * 10;
    }

    public void turnAroundRadius()
    {
        newTurnAroundRadiusValue += counterTurnAroundRadius;
        transform.localScale = new Vector3(newTurnAroundRadiusValue, newTurnAroundRadiusValue, newTurnAroundRadiusValue);

        newBallScale = ballScale / newTurnAroundRadiusValue;

        for (int i = 0; i < ballsList.Count; i++)
        {
            ballsList[i].transform.localScale = new Vector3(newBallScale, newBallScale, newBallScale);
        }

    }

    private void OnEnable()
    {
        EventManager.TurnAround.AddListener(turnAroundRadius);
    }

    private void OnDisable()
    {
        EventManager.TurnAround.RemoveListener(turnAroundRadius);
    }
}
