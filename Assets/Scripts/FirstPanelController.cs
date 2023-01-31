using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPanelController : MonoBehaviour
{
    public static FirstPanelController instance;

    [SerializeField] private List<GameObject> skillList,skillUIPoint = new List<GameObject>();

    // [SerializeField] private GameObject[] skills;
    // [SerializeField] private GameObject[] skillUIPoint;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        randomSkillChoice();
    }

    public void randomSkillChoice()
    {
        List<GameObject> tempList = new List<GameObject>();
       
        for (int i = 0; i < skillList.Count; i++)
        {
            tempList.Add(skillList[i]);
        }

        for (int i = 0; i < skillUIPoint.Count; i++)
        {
            int randomNum = Random.Range(0, tempList.Count);
            tempList[randomNum].transform.position = skillUIPoint[i].transform.position;
            tempList[randomNum].SetActive(true);
            tempList.Remove(tempList[randomNum]);
        }
    }

    private void OnDisable()
    {
        Debug.Log("Disable !");
        for (int i = 0; i < skillList.Count; i++)
        {
            skillList[i].SetActive(false);
        }

        /*if (ExpPanelController.instance.levelCounter > 1)
        {
            randomSkillChoice();
            ExpPanelController.instance.levelCounter--;
            ButtonController.instance.firstSkillPanel.SetActive(true);
            Debug.Log(ExpPanelController.instance.levelCounter);
        }*/

    }
}
