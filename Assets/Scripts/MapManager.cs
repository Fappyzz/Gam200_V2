using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] Button T2MapTop;
    [SerializeField] Button T2MapBot;
    [SerializeField] Button T3MapTop;
    [SerializeField] Button T3MapBot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpMaps()
    {
        if (MapTier == 0)
        {
            T2MapTop.interactable = true;
            T2MapBot.interactable = true;

            T3MapTop.interactable = false;
            T3MapBot.interactable = false;
        }
        else if (MapTier == 1)
        {
            T2MapTop.interactable = false;
            T2MapBot.interactable = false;

            T3MapTop.interactable = true;
            T3MapBot.interactable = true;
        }
        else if (MapTier > 1)
        {
            T2MapTop.interactable = false;
            T2MapBot.interactable = false;

            T3MapTop.interactable = false;
            T3MapBot.interactable = false;
        }
    }

    public void NextMap()
    {
        MapTier++;
    }
    public void TopMap()
    {
        MapChoice = 0;
    }
    public void BotMap()
    {
        MapChoice = 1;
    }
}
