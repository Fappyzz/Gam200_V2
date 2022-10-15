using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static GameData;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<UnitBody> playerTrainList = new List<UnitBody>();

    [Space(10)]

    [SerializeField] List<UnitBody> enemyTrainList = new List<UnitBody>();

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
    Vector2 playerTrainStartingPos = new Vector2(0.5f, -3);
    [SerializeField] GameObject enemyTrainGO;
    Vector2 enemyTrainStartingPos = new Vector2(0.5f, 3);
    bool combatEnd = false;
    [SerializeField] GameObject victoryText;
    float victoryTimer = 2f;

    [Space(10)]
    
    [SerializeField] GameObject ResultCanvas;

    [Space(10)]

    [SerializeField] GameObject PrepCanvas;
    Vector3 prepCamPos = new Vector3(0, -15, -10);

    [Space(10)]

    [SerializeField] GameObject MapCanvas;

    [Space(10)]

    [SerializeField] GameObject TutCanvas;

    [SerializeField] GameObject TopBlackScreen;
    [SerializeField] GameObject BotBlackScreen;
    float clapVelo = 0f;
    float clapTimer = 1.5f;
    bool clap = false;
    bool unclap = false;

    // Time taken for the transition.
    float thingyTimer = 0.3f;
    float thingyTimer2 = 0.3f;

    bool moveThingy = false;
    bool moveThingy2 = false;

    float velo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        TurnOffAllCanvas();

        MainCam.transform.position = menuCamPos;
        MenuCanvas.SetActive(true);

        playerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 2)));
        playerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 2)));
        playerUnits.Add(new Unit("test unit", 10, new Bullet("test bullet", 2, 10), new Gun("test gun", 2)));

        enemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 2, 5), new Gun("test gun", 1)));
        enemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 2, 6), new Gun("test gun", 2)));
        enemyUnits.Add(new Unit("test unit", 6, new Bullet("test bullet", 2, 7), new Gun("test gun", 3)));

        PrepAllUnits();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.K))
        {
            TopBlackScreen.transform.position = new Vector3(0, 6, -10);
        }*/
        /*if (CheckPlayerTeamDead())
        {
            CurrentGameState = GameState.Result;
            CombatCam.enabled = false;
            ResultCam.enabled = true;
        }*/

        if (Input.GetKeyDown(KeyCode.G))
        {
            moveThingy = true;
        }
        if (moveThingy)
        {
            float newPosition = Mathf.SmoothDamp(MainCam.transform.position.x, -18, ref velo, thingyTimer);
            MainCam.transform.position = new Vector3(newPosition, -15, -10);
            thingyTimer -= Time.deltaTime;
            if (thingyTimer < 0)
            {
                moveThingy = false;
                thingyTimer = 0.3f;
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            moveThingy2 = true;
        }
        if (moveThingy2)
        {
            float newPosition = Mathf.SmoothDamp(MainCam.transform.position.x, 0, ref velo, thingyTimer2);
            MainCam.transform.position = new Vector3(newPosition, -15, -10);
            thingyTimer2 -= Time.deltaTime;
            if (thingyTimer2 < 0)
            {
                moveThingy2 = false;
                thingyTimer2 = 0.3f;
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
                clapTimer = 1.5f;
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
                clapTimer = 1.5f;
                TopBlackScreen.SetActive(false);
                BotBlackScreen.SetActive(false);
            }
        }

        if (CheckEnemyTeamDead() == true && combatEnd == false && CurrentGameState == GameState.Combat)
        {
            victoryText.SetActive(true);
            victoryTimer -= Time.deltaTime;
            if (victoryTimer < 0)
            {
                ChangeTo("Result");
                combatEnd = true;
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
                if (TutCount == 0)
                {
                    TutSetUpF = SetupTut;
                }
                ClapScreen();
                break;

            case "Result":
                CurrentGameState = GameState.Result;
                CanShootAllUnits(false);
                ResultCanvas.SetActive(true);
                break;

            case "Prep":
                CurrentGameState = GameState.Result;
                SetUpF = SetupPrepState;
                if (TutCount == 4)
                {
                    TutSetUpF = SetupTut;
                }
                ClapScreen();
                break;
            case "Map":
                moveThingy = true;
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
        MainCam.transform.position = combatCamPos;
        playerTrainGO.transform.position = playerTrainStartingPos;
        enemyTrainGO.transform.position = enemyTrainStartingPos;
    }

    void SetupPrepState()
    {
        PrepCanvas.SetActive(true);
        MainCam.transform.position = prepCamPos;
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
        /*MapCanvas.SetActive(false);*/
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
    public void CanShootAllUnits(bool set)
    {
        for (int i = 0; i < playerTrainList.Count; i++)
        {
            playerTrainList[i].CanShoot = set;
        }
        for (int i = 0; i < enemyTrainList.Count; i++)
        {
            enemyTrainList[i].CanShoot = set;
        }
    }
}
