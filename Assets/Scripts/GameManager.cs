using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;
using UnityEngine.UI;
using TMPro;
using static Unitf;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<UnitBody> playerTrainList = new List<UnitBody>();

    [Space(10)]

    [SerializeField] List<UnitBody> enemyTrainList = new List<UnitBody>();

    [Space(10)]

    [SerializeField] GameObject HeatBar;

    [Space(10)]

    [SerializeField] public List<ItemBody> playerInventory = new List<ItemBody>();

    [Space(10)]

    [SerializeField] Camera MainCam;
    public delegate void SetUp();
    SetUp SetUpF;
    SetUp TutSetUpF;

    [Space(10)]

    [SerializeField] GameObject MenuCanvas;
    Vector3 menuCamPos = new Vector3(0, 15, -10);

    [Space(10)]

    [SerializeField] GameObject CombatCanvas;
    Vector3 combatCamPos = new Vector3(0, 0, -10);
    [SerializeField] GameObject playerTrainGO;
    Vector2 playerTrainStartingPos = new Vector2(0.5f, -2);
    [SerializeField] GameObject enemyTrainGO;
    Vector2 enemyTrainStartingPos = new Vector2(0.5f, 2);
    bool combatEnd = false;
    [SerializeField] GameObject victoryText;
    float victoryTimer = 2f;

    [Space(10)]
    
    [SerializeField] GameObject ResultCanvas;

    [Space(10)]

    [SerializeField] GameObject PrepCanvas;
    Vector3 prepCamPos = new Vector3(0, -15, -10);
    [SerializeField] GameObject PrepGOs;
    [SerializeField] GameObject PrepButtonGO;
    [SerializeField] Button PrepButtonComp;
    [SerializeField] TextMeshProUGUI PrepButtonTMP;

    [Space(10)]



    [SerializeField] GameObject TutCanvas;
    [SerializeField] Button Tut0ButtonComp;

    [Space(10)]

    [SerializeField] GameObject TopBlackScreen;
    [SerializeField] GameObject BotBlackScreen;
    float clapVelo = 0f;
    float clapTimer = 0.5f;
    bool clap = false;
    bool unclap = false;

    [Space(10)]

    

    // Time taken for the transition.
    float thingyTimer = 0.5f;
    float thingyTimer2 = 0.5f;

    bool moveThingy = false;
    bool moveThingy2 = false;

    float thingyTimer3 = 0.5f;
    float thingyTimer4 = 0.5f;

    bool moveThingy3 = false;
    bool moveThingy4 = false;

    float velo = 0f;
    float velo2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        TurnOffAllCanvas();

        MainCam.transform.position = menuCamPos;
        MenuCanvas.SetActive(true);

        PlayerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 0.5f), new Skill("Buff", 0, 10, 1, 5)));
        PlayerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 0.5f), new Skill("Explosion", 1, 10)));
        PlayerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 0.5f), new Skill("Explosion", 1, 10)));

        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 5), new Gun("test gun", 1), new Skill("Blank", 0, 10)));
        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 6), new Gun("test gun", 2), new Skill("Blank", 0, 10)));
        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 7), new Gun("test gun", 3), new Skill("Blank", 0, 10)));

        PrepAllUnits();

        Tut0ButtonComp.interactable = false;

        PrepAllItems();
    }

    // Update is called once per frame
    void Update()
    {


        if (moveThingy)
        {
            float newPosition = Mathf.SmoothDamp(PrepGOs.transform.localPosition.x, -1750, ref velo, thingyTimer);
            PrepGOs.transform.localPosition = new Vector2(newPosition, 0);
            thingyTimer -= Time.deltaTime;
            if (thingyTimer < 0)
            {
                moveThingy = false;
                thingyTimer = 0.5f;
            }
        }
        if (moveThingy2)
        {
            float newPosition = Mathf.SmoothDamp(PrepGOs.transform.localPosition.x, 0, ref velo, thingyTimer2);
            PrepGOs.transform.localPosition = new Vector2(newPosition, 0);
            thingyTimer2 -= Time.deltaTime;
            if (thingyTimer2 < 0)
            {
                moveThingy2 = false;
                thingyTimer2 = 0.5f;
            }
        }
        
        if (moveThingy3)
        {
            float newPosition = Mathf.SmoothDamp(PrepButtonGO.transform.localPosition.x, 1050, ref velo2, thingyTimer3);
            PrepButtonGO.transform.localPosition = new Vector2(newPosition, PrepButtonGO.transform.localPosition.y);
            thingyTimer3 -= Time.deltaTime;
            if (thingyTimer3 < 0)
            {
                moveThingy3 = false;
                thingyTimer3 = 0.5f;
                PrepButtonComp.interactable = true;
            }
        }

        if (moveThingy4)
        {
            float newPosition = Mathf.SmoothDamp(PrepButtonGO.transform.localPosition.x, 700, ref velo2, thingyTimer4);
            PrepButtonGO.transform.localPosition = new Vector2(newPosition, PrepButtonGO.transform.localPosition.y);
            thingyTimer4 -= Time.deltaTime;
            if (thingyTimer4 < 0)
            {
                moveThingy4 = false;
                thingyTimer4 = 0.5f;
                PrepButtonComp.interactable = true;
            }
        }

        /*if (Input.GetKeyUp(KeyCode.L))
        {
            ClapScreen();
        }*/
        if (clap)
        {
            float newPosition = Mathf.SmoothDamp(TopBlackScreen.transform.localPosition.y, 500, ref clapVelo, clapTimer);
            TopBlackScreen.transform.localPosition = new Vector2(0, newPosition);
            BotBlackScreen.transform.localPosition = new Vector2(0, -newPosition);
            clapTimer -= Time.deltaTime;
            if (clapTimer < 0)
            {
                clapVelo = 0f;
                clap = false;
                clapTimer = 0.5f;
                unclap = true;

                TurnOffAllCanvas();
                SetUpF?.Invoke();

                TutSetUpF?.Invoke();
                TutSetUpF = null;
            }
        }
        if (unclap)
        {
            float newPosition = Mathf.SmoothDamp(TopBlackScreen.transform.localPosition.y, 1050, ref clapVelo, clapTimer);
            TopBlackScreen.transform.localPosition = new Vector3(0, newPosition);
            BotBlackScreen.transform.localPosition = new Vector3(0, -newPosition);
            clapTimer -= Time.deltaTime;
            if (clapTimer < 0)
            {
                clapVelo = 0f;
                unclap = false;
                clapTimer = 0.5f;
                TopBlackScreen.SetActive(false);
                BotBlackScreen.SetActive(false);
                if (CurrentGameState == GameState.Combat)
                {
                    CanShootAllUnits(true);
                    if (TutCount == 0)
                    {
                        CanShootAllUnits(false);
                        Tut0ButtonComp.interactable = true;
                    }
                }
            }
        }

        if (CheckEnemyTeamDead() == true && combatEnd == false && CurrentGameState == GameState.Combat)
        {
            victoryText.SetActive(true);
            victoryTimer -= Time.deltaTime;
            if (victoryTimer < 0)
            {
                combatEnd = true;
                ChangeTo("Result");
                victoryText.SetActive(false);
                victoryTimer = 2f;
            }
        }
    }

    public bool CheckEnemyTeamDead()
    {
        for (int i = 0; i < enemyTrainList.Count; i++)
        {
            if (enemyTrainList[i].thisUnit.IsDead == false)
            {
                return false;
            }
        }

        return true;
    }

    public void ClapScreen()
    {
        if (!clap && !unclap)
        {
            clap = true;
            TopBlackScreen.SetActive(true);
            BotBlackScreen.SetActive(true);
        }
    }

    public void ChangeTo(string state)
    {
        //{ Menu, Combat, Result, Prep, Map }
        switch (state)
        {
            case "Menu":
                CurrentGameState = GameState.Menu;
                SetUpF = SetupMenuState;
                ClapScreen();
                break;

            case "Combat":
                CurrentGameState = GameState.Combat;
                SetUpF = SetupCombatState;
                CanShootAllUnits(false);
                if (TutCount == 0)
                {
                    TutSetUpF = SetupTut;
                }
                else
                {
                    SpawnEnemyUnits();
                }
                ClapScreen();
                break;

            case "Result":
                CurrentGameState = GameState.Result;

                GenerateLoot();
                PrepAllItems();

                CanShootAllUnits(false);
                ResultCanvas.SetActive(true);
                break;

            case "Prep":
                foreach (Unit unit in PlayerUnits)
                {
                    EndCombatTempHpMod(unit);
                }
                if (CurrentGameState == GameState.Prep)
                {
                    CurrentGameState = GameState.Map;
                    PrepButtonTMP.text = "See Train";
                    moveThingy = true;
                    moveThingy3 = true;
                    PrepButtonComp.interactable = false;
                }
                else if (CurrentGameState == GameState.Map)
                {
                    CurrentGameState = GameState.Prep;
                    PrepButtonTMP.text = "See Map";
                    moveThingy2 = true;
                    moveThingy4 = true;
                    PrepButtonComp.interactable = false;
                }
                else
                {
                    CurrentGameState = GameState.Prep;
                    combatEnd = false;
                    SetUpF = SetupPrepState;
                    if (TutCount == 4)
                    {
                        TutSetUpF = SetupTut;
                    }
                    ClapScreen();
                }
                break;
        }

        
    }
    void SetupMenuState()
    {
        MenuCanvas.SetActive(true);
        MainCam.transform.position = menuCamPos;
    }

    void SetupCombatState()
    {
        CombatCanvas.SetActive(true);
        if (HeatBar.activeSelf != true)
        {
            HeatBar.SetActive(true);
        }
        MainCam.transform.position = combatCamPos;
        playerTrainGO.transform.position = playerTrainStartingPos;
        enemyTrainGO.transform.position = enemyTrainStartingPos;
    }

    void SetupPrepState()
    {
        PrepCanvas.SetActive(true);
        MainCam.transform.position = prepCamPos;
        PrepGOs.transform.localPosition = new Vector2(0, 0);
        PrepButtonGO.transform.localPosition = new Vector2(700, 215);
        PrepButtonTMP.text = "See Map";
    }

    void SetupTut()
    {
        TutCanvas.SetActive(true);
    }

    void TurnOffAllCanvas()
    {
        MenuCanvas.SetActive(false);
        CombatCanvas.SetActive(false);
        ResultCanvas.SetActive(false);
        PrepCanvas.SetActive(false);
        TutCanvas.SetActive(false);
    }

    void PrepAllUnits()
    {
        for (int i = 0; i < playerTrainList.Count; i++)
        {
            playerTrainList[i].UpdateUnitBody();
        }
        for (int i = 0; i < enemyTrainList.Count; i++)
        {
            enemyTrainList[i].UpdateUnitBody();
        }
    }

    void PrepAllItems()
    {
        for (int i = 0; i < playerInventory.Count; i++)
        {
            playerInventory[i].UpdateItemBody();
        }
    }

    void GenerateLoot()
    {
        if (Random.Range(1, 3) == 1)
        {
            PlayerItems.Add(new Item("Repair kit", "Restore some health to your unit.", Item.ModType.Heal, 2));
        }
        else
        {
            PlayerItems.Add(new Item("Armor", "Restore health and increase max health to your unit.", Item.ModType.Hp, 1));
        }
    }

    public void CanShootAllUnits(bool set)
    {
        for (int i = 0; i < playerTrainList.Count; i++)
        {
            playerTrainList[i].CanShoot = set;
            playerTrainList[i].AutoAttackTimer = playerTrainList[i].thisGun.AutoAttTimer;
        }
        for (int i = 0; i < enemyTrainList.Count; i++)
        {
            enemyTrainList[i].CanShoot = set;
            enemyTrainList[i].AutoAttackTimer = enemyTrainList[i].thisGun.AutoAttTimer;
        }
    }
    void SpawnEnemyUnits()
    {
        EnemyUnits.Clear();

        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 5), new Gun("test gun", 1), new Skill("Blank", 0, 10)));
        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 6), new Gun("test gun", 2), new Skill("Blank", 0, 10)));
        EnemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 1, 7), new Gun("test gun", 3), new Skill("Blank", 0, 10)));

        PrepAllUnits();
    }
}
