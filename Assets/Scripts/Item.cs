using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unitf;

public class Item
{
    public enum ModType { Hp, Heal, Skill, Bullet, Gun }
    public string Name { get; set; }
    public string Desc { get; set; } = "test";

    public int Mod { get; set; } = 0;
    public ModType Type { get; set; }

    public int Mod2 { get; set; } = 0;
    public ModType Type2 { get; set; }

    public Skill skill;
    public Bullet bullet;
    public Gun gun;

    public Item(string name, ModType type,  int mod)
    {
        Name = name;
        Type = type;
        Mod = mod;
    }

    public Item(string name, ModType type, int mod, ModType type2, int mod2)
    {
        Name = name;
        Type = type;
        Mod = mod;
        Type2 = type;
        Mod2 = mod2;
    }

    public Item(string name, ModType type, Skill skill)
    {
        Name = name;
        Type = type;
        this.skill = skill;
    }

    public Item(string name, ModType type, Bullet bullet)
    {
        Name = name;
        Type = type;
        this.bullet = bullet;
    }

    public Item(string name, ModType type, Gun gun)
    {
        Name = name;
        Type = type;
        this.gun = gun;
    }
}

public static class Itemf
{
    public static void ConsumeItem(Item item, Unit target)
    {
        switch (item.Type)
        {
            case Item.ModType.Hp:
                PermHpMod(target, item.Mod);
                break;

            /*case Item.ModType.Dmg:
                //PermDmgMod(target, item.Mod);
                break;*/

            case Item.ModType.Heal:
                HealUnit(target, item.Mod);
                break;

            default:
                break;
        }

        if (item.Mod2 != 0)
        {
            switch (item.Type2)
            {
                case Item.ModType.Hp:
                    PermHpMod(target, item.Mod2);
                    break;

                /*case Item.ModType.Dmg:
                    //PermDmgMod(target, item.Mod2);
                    break;*/

                case Item.ModType.Heal:
                    HealUnit(target, item.Mod2);
                    break;

                default:
                    break;
            }
        }
    }
}
