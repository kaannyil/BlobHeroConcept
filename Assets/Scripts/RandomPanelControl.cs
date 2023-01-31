using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPanelControl : MonoBehaviour
{
    public static RandomPanelControl instance;

    [SerializeField] private List<GameObject> skillList,tempList = new List<GameObject>();
    [SerializeField] private Transform[] skillUIPoint;
    [HideInInspector] public bool changeAllow = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    /*private void Start()
    {
        StartCoroutine(skillChangeEnum());
    }
    IEnumerator skillChangeEnum()
    {
        for (int i = 0; i < skillUIPoint.Length; i++)
        {
            int randomNum = Random.Range(0, tempList.Count);
            tempList[randomNum].transform.position = skillUIPoint[i].transform.position;
            tempList[randomNum].SetActive(true);
            tempList.Remove(tempList[randomNum]);
        }

        // tempList = skillList;

        yield return new WaitForSeconds(.2f);
    }*/
    private void Update()
    {
        if (changeAllow == true)
        {
            randomSkillFunc();
            tempList = skillList;
        }
    }
    public void randomSkillFunc()
    {
        if (this.gameObject.activeInHierarchy)
        {
            for (int i = 0; i < skillUIPoint.Length; i++)
            {
                int randomNum = Random.Range(0, tempList.Count);
                tempList[randomNum].transform.position = skillUIPoint[i].transform.position;
                tempList[randomNum].SetActive(true);
                tempList.Remove(tempList[randomNum]);
            }
            changeAllow = false;
        }
    }
}