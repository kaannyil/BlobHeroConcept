using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncreaseSkill : MonoBehaviour
{
    public static DamageIncreaseSkill instance;

    private void Awake()
    {
        instance = this;
    }
    public void damageIncrease()
    {
        /*float turnAroundDamage = TurnAround.instance.currentDamage;
        float CCDamage = ContinuosCylindir.instance.currentDamage;
        float nearlyShootDamage = NearlyShootCreate.instance.currentDamage;*/

        TurnAround.instance.currentDamage += ((TurnAround.instance.currentDamage * 10) / 100);
        ContinuosCylindir.instance.currentDamage += ((ContinuosCylindir.instance.currentDamage * 10) / 100);
        NearlyShootCreate.instance.currentDamage += ((NearlyShootCreate.instance.currentDamage * 10) / 100);
    }
}
