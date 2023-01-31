using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    [SerializeField] private GameObject[] UIObjects, skills;
    [SerializeField] private GameObject startPanel;

    public GameObject firstSkillPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        if (firstSkillPanel.activeInHierarchy)
        {
            Time.timeScale = 0.3f;
        }
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void continueButton(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void startButton()
    {
        startPanel.SetActive(false);
        firstSkillPanel.SetActive(true);

        for (int i = 0; i < UIObjects.Length; i++)
        {
            UIObjects[i].SetActive(true);
        }
    }
    public void continuousCylendirSkill()
    {
        if (!skills[0].activeInHierarchy)
        {
            skills[0].SetActive(true);
        }
        else
        {
            ContinuosCylindir.instance.cylendirRadiusAndDamage();
        }

        firstSkillPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void turnAroundSkill()
    {
        if (!skills[1].activeInHierarchy)
        {
            skills[1].SetActive(true);
        }
        else
        {
            /*TurnAroundFunction.instance.turnAroundRadius();
            TurnAround.instance.damageAndRotationSpeed();*/

            EventManager.TurnAround.Invoke();
        }
        
        firstSkillPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void nearlyShootSkill()
    {
        if (!skills[2].activeInHierarchy)
        {
            skills[2].SetActive(true);
        }
        else
        {
            NearlyShootCreate.instance.updateNearlyShoot();
        }

        firstSkillPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void maxHPSkill()
    {
        PlayerController.instance.maxHealth += (int)(PlayerController.instance.maxHealth * 20 / 100);

        firstSkillPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void HPRegenerationSkill()
    {
        if (!skills[3].activeInHierarchy)
        {
            skills[3].SetActive(true);
        }

        else HPRegeneration.instance.regenerationValue += 2;

        firstSkillPanel.SetActive(false);

        Time.timeScale = 1;
    }

    public void MagnetSkill()
    {
        MagnetDistance.instance.DistanceIncrease();
        firstSkillPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void damageIncreaseButton()
    {
        TurnAround.instance.currentDamage += ((TurnAround.instance.currentDamage * 10) / 100);

        /*ContinuosCylindir.instance.currentDamage += ((ContinuosCylindir.instance.currentDamage * 10) / 100);
        NearlyShootCreate.instance.currentDamage += ((NearlyShootCreate.instance.currentDamage * 10) / 100);*/

        firstSkillPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
