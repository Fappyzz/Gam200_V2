using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameData;
using TMPro;

public class Heatbar : MonoBehaviour
{
    public TextMeshProUGUI mHeat;
    public TextMeshProUGUI cHeat;

    [SerializeField] Image fill;
    [SerializeField]float Fillfloat;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Fillfloat = Heat * 0.02f;
        fill.fillAmount = Fillfloat;
        mHeat.text = MaxHeat.ToString();
        cHeat.text = Heat.ToString();
        
    }
}
