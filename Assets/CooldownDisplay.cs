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
    [SerializeField] Button skillButton;
    [SerializeField] Button UiSkillButton;

    [SerializeField] UnitBody body;
    Image img;

    bool skillpressed;

    int cooldown;
    float countdownCooldown;

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
            UiSkillButton.gameObject.SetActive(false);
        }
        else
        {
            img.enabled = true;
            UiSkillButton.gameObject.SetActive(true);
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
        body.ShootBullet();
        skillButton.enabled = false;
        UiSkillButton.enabled = false;
    }

    public void Countdown()
    {
        clockCD.fillAmount -= Time.deltaTime/cooldown ;
        if (clockCD.fillAmount <= 0)
        {
            skillButton.enabled = true;
            UiSkillButton.enabled = true;
            skillpressed = false;
            clockCD.gameObject.SetActive(false);

        }
        
    }

    

}
