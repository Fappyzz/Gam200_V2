using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;

public class TutManager : MonoBehaviour
{
    [SerializeField] GameObject TutCanvas;

    [SerializeField] List<GameObject> TutList = new List<GameObject>();

    /*[SerializeField] GameObject Tut0;
    [SerializeField] GameObject Tut1;
    [SerializeField] GameObject Tut2;
    [SerializeField] GameObject Tut3;
    [SerializeField] GameObject Tut4;*/
    // Start is called before the first frame update
    void Start()
    {
        TurnOffAllTut();
        TutList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTut()
    {
        TurnOffAllTut();

        if (TutCount == 0)
        {
            TutCount = 1;
            TutList[1].SetActive(true);
        }
        else if (TutCount == 1)
        {
            TutCount = 2;
            TutList[2].SetActive(true);
        }
        else if (TutCount == 2)
        {
            TutCount = 3;
            TutList[3].SetActive(true);
        }
        else if (TutCount == 3)
        {
            TutCount = 4;
            TutList[4].SetActive(true);
        }
        else if (TutCount == 4)
        {
            TutCount = 5;
            TutList[5].SetActive(true);
        }
    }

    void TurnOffAllTut()
    {
        for (int i = 0; i < TutList.Count; i++)
        {
            TutList[i].SetActive(false);
        }
    }

    public void OffTutCanvas()
    {
        TutCanvas.SetActive(false);
    }
}
