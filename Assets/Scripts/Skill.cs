using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillActives;
using static GameData;

public class Skill
{
    public string Name { get; set; }

    public int SkillRef { get; set; }
    public int CoolDownTimer { get; set; } = 6;

    public delegate void SkillFunction();
    SkillFunction skillF;

    public Skill(string name, int skillRef, int cdTimer)
    {
        Name = name;
        CoolDownTimer = cdTimer;

        switch (skillRef)
        {
            case 1:
                skillF = DamageEnemy;
                break;

            default:
                skillF = null;
                break;
        }
    }

    public void ActivateSkill()
    {
        skillF?.Invoke();
    }
}

public static class SkillActives
{
    public static void DamageEnemy()
    {
        Debug.Log("Skill works");
    }
}
