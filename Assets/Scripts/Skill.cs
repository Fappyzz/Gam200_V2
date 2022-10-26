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

    public int TargetRef { get; set; }
    public int Mod { get; set; }
    public bool HasMod { get; set; }

    public delegate void SkillFunction();
    SkillFunction noModSkillF;

    public delegate void SkillFunctionWithMod(int target, int mod);
    SkillFunctionWithMod modSkillF;


    public Skill(string name, int skillRef, int cdTimer)
    {
        Name = name;
        CoolDownTimer = cdTimer;

        switch (skillRef)
        {
            case 0:
                noModSkillF = Blank;
                break;

            case 1:
                noModSkillF = Explosive;
                break;

            case 2:
                noModSkillF = MGFire;
                //noModSkillF = BuffHP;
                break;

            default:
                noModSkillF = null;
                break;
        }
    }
    
    public Skill(string name, int skillRef, int cdTimer, int targetRef, int mod)
    {
        Name = name;
        CoolDownTimer = cdTimer;
        TargetRef = targetRef;
        Mod = mod;
        HasMod = true;

        switch (skillRef)
        {
            case 0:
                modSkillF = BuffHP;
                break;

            default:
                modSkillF = null;
                break;
        }
    }

    public void ActivateSkill()
    {
        if (HasMod == true)
        {
            modSkillF?.Invoke(TargetRef, Mod);
        }
        else
        {
            noModSkillF?.Invoke();
        }
    }
}

public static class SkillActives
{
    public static void Explosive()
    {
        //Damages Adjacent units
        Debug.Log("Explosion");

    }
    public static void MGFire()
    {
        //Fires a set number of shots in quick succession
    }

    public static void BuffHP(int target, int mod)
    {

        Unitf.CombatTempHpMod(PlayerUnits[target], mod);
        //buffs adjacent MAXHP
    }
    public static void Blank()
    {
        //Nothing
    }
}
