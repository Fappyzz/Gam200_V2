using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public string Name { get; set; }

    public int Dmg { get; set; } = 1;
    public int Speed { get; set; } = 5;

    public Bullet(string name, int dmg, int speed)
    {
        Name = name;
        Dmg = dmg;
        Speed = speed;
    }
}
