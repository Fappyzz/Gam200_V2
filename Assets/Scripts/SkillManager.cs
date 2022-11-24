using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameData;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Image unit0UnitImg;
    [SerializeField] Image unit1UnitImg;
    [SerializeField] Image unit2UnitImg;
    
    [SerializeField] Image unit0UiImg;
    [SerializeField] Image unit1UiImg;
    [SerializeField] Image unit2UiImg;

    [SerializeField] Sprite shieldUnit;

    bool change0 = false;
    bool change1 = false;
    bool change2 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerUnits[0].Bullet = new Bullet("test shield", 1);
        }
        
        if (PlayerUnits[0].Bullet.IsShield == true)
        {
            unit0UnitImg.sprite = shieldUnit;
            unit0UnitImg.rectTransform.sizeDelta = new Vector2(50, 50);
            unit0UnitImg.rectTransform.anchoredPosition = new Vector2(0, -10);
            unit0UiImg.sprite = shieldUnit;

        }
        if (PlayerUnits[1].Bullet.IsShield == true )
        {
            unit1UnitImg.sprite = shieldUnit;
            unit1UnitImg.rectTransform.sizeDelta = new Vector2(50, 50);
            unit1UnitImg.rectTransform.anchoredPosition = new Vector2(0, -10);
            unit1UiImg.sprite = shieldUnit;

        }
        if (PlayerUnits[2].Bullet.IsShield == true )
        {
            unit2UnitImg.sprite = shieldUnit;
            unit2UnitImg.rectTransform.sizeDelta = new Vector2(50, 50);
            unit2UnitImg.rectTransform.anchoredPosition = new Vector2(0, -10);
            unit2UiImg.sprite = shieldUnit;

        }
    }
}
