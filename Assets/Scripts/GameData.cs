using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public enum GameState { Menu, Combat, Result, Prep, Map }
    public static GameState CurrentGameState { get; set; } = GameState.Menu;
    public static int TutCount { get; set; } = 0;
    public static bool UsingSkillState { get; set; } = false;

    public static int Heat { get; set; } = 10;
    public static int MaxHeat { get; set; } = 50;

    public static int MaxTrainSpeed { get; set; } = 10;
    public static float TrainSpeed { get; set; } = 1;
    public static float TrainAcc { get; set; } = 0.2f;
    
    public static int EnemyMaxTrainSpeed { get; set; } = 10;
    public static float EnemyTrainSpeed { get; set; } = 1;
    public static float EnemyTrainAcc { get; set; } = 0.2f;

    public static List<Item> allItemsRef = new List<Item>();

    //public static List<Skill> allSkillsRef = new List<Skill>();
    public static List<Bullet> allBulletsRef = new List<Bullet>();
    public static List<Gun> allGunsRef = new List<Gun>();

    public static List<Unit> playerUnits = new List<Unit>();
    public static List<Unit> enemyUnits = new List<Unit>();

    public static List<Item> storedPlayerItems = new List<Item>();
    public static List<int> storedPlayerItemsSlots = new List<int>();
}
