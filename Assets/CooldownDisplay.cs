using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static GameData;
using static Unitf;

public class CooldownDisplay : MonoBehaviour
{
    [SerializeField] Image clockCD;
    [SerializeField] TextMeshProUGUI cooldownTimer;

    bool skillpressed;

    int cooldown;
    float countdownCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer.text = Mathf.FloorToInt(countdownCooldown).ToString(); 
        if (skillpressed)
        {
            Countdown();
            countdownCooldown -= 1 * Time.deltaTime;
            
        }
    }

    public void SkillPressed()
    {
        clockCD.fillAmount = 1;
        clockCD.gameObject.SetActive(true);
        skillpressed = true;
        cooldown = 10;
        countdownCooldown = 10;
    }
    public void Countdown()
    {
        clockCD.fillAmount -= Time.deltaTime/cooldown ;
        if (clockCD.fillAmount <= 0)
        {
            skillpressed = false;
            clockCD.gameObject.SetActive(false);

        }
        
    }

    

}
