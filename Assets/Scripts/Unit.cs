using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;

public class Unit
{
    public string Name { get; set; }

    public int MaxHp { get; set; }
    public int Hp { get; set; }

    public int TempHp { get; set; }

    public Skill Skill { get; set; }
    public Bullet Bullet { get; set; }
    public Gun Gun { get; set; }

    public bool IsDead { get; set; } = false;

    public Unit(string name, int maxHp, Bullet bullet, Gun gun)
    {
        Name = name;
        MaxHp = maxHp;
        Hp = MaxHp;

        Bullet = bullet;
        Gun = gun;
    }
}

public static class Unitf
{
    public static void PrepFreshUnit(Unit target)
    {
        target.Hp = target.MaxHp;
    }

    public static void DamageUnit(Unit target, int dmg)
    {
        if (target.IsDead == false)
        {
            target.Hp -= dmg;

            if (target.Hp <= 0)
            {
                target.Hp = 0;
                target.IsDead = true;
            }
        }
        else
        {
            Heat -= dmg;
        }
    }
    public static void DamageUnit(Unit target, Bullet bullet)
    {
        if (target.IsDead == false)
        {
            target.Hp -= bullet.Dmg;

            if (target.Hp <= 0)
            {
                target.Hp = 0;
                target.IsDead = true;
            }
        }
        else
        {
            Heat -= bullet.Dmg;
        }
    }

    public static void HealUnit(Unit target, int heal)
    {
        target.Hp += heal;

        if (target.IsDead == true)
        {
            target.IsDead = false;
        }

        if (target.Hp > target.MaxHp)
        {
            target.Hp = target.MaxHp;
        }
    }
    
    public static void CombatTempHpMod(Unit target, int mod)
    {
        target.TempHp += mod;

        target.Hp += mod;
        target.MaxHp += mod;
    }
    public static void EndCombatTempHpMod(Unit target)
    {
        target.Hp -= target.TempHp;

        if (target.Hp <= 0)
        {
            target.Hp = 1;
        }

        target.MaxHp -= target.TempHp;

        if (target.MaxHp <= 0)
        {
            target.MaxHp = 1;
        }
    }
    
    public static void PermHpMod(Unit unit, int mod)
    {
        unit.Hp += mod;
        unit.MaxHp += mod;
    }
}
