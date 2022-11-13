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

    [SerializeField] UnitBody body;
    Image img;

    bool skillpressed;

    float cooldown;
    float countdownCooldown;
    public bool canUse = true;

    // Start is called before the first frame update
    void Start()
    {
        
        if (GetComponent<Image>() != null)
        {
            img = GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (body.thisUnit.Skill == null)
        {
            img.enabled = false;
        }
        else
        {
            img.enabled = true;
        }

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
        cooldown = body.thisUnit.Skill.CoolDownTimer;
        countdownCooldown = body.thisUnit.Skill.CoolDownTimer;
        canUse = false;
    }

    public void Countdown()
    {
        clockCD.fillAmount -= Time.deltaTime/cooldown ;
        if (clockCD.fillAmount <= 0)
        {
            skillpressed = false;
            canUse = true;
            clockCD.gameObject.SetActive(false);

        }
        
    }

    

}
