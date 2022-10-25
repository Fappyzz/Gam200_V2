using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData;
using TMPro;

public class Heatbar : MonoBehaviour
{
    public TextMeshProUGUI mHeat;
    public TextMeshProUGUI cHeat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mHeat.text = MaxHeat.ToString();
        cHeat.text = Heat.ToString();
    }
}
