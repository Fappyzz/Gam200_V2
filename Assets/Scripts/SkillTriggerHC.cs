using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameData;
using static Unitf;

public class SkillTriggerHC : MonoBehaviour
{
    [SerializeField] UnitBody SelectedSkill;
    [SerializeField] int skillRef = 0;
    [SerializeField] List<UnitBody> AvailableSkills;
    [SerializeField] GameObject skill0;
    [SerializeField] GameObject skill1;
    [SerializeField] GameObject skill2;

    [SerializeField] UnitBody unit0;
    [SerializeField] UnitBody unit1;
    [SerializeField] UnitBody unit2;


    CooldownDisplay cooldownDisplay;

    void Start()
    {
        skillRef = 0;
        SelectedSkill = AvailableSkills[0];

        skill1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        skill2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        //skill1.SetActive(false);
        //skill2.SetActive(false);

    }

    void Update()
    {
        if (unit0.thisUnit.Skill == null)
        {
            skill0.SetActive(false);
        }
        else
        {
            skill0.SetActive(true);
        }

        if (unit1.thisUnit.Skill == null)
        {
            skill1.SetActive(false);
        }
        else
        {
            skill1.SetActive(true);
        }

        if (unit2.thisUnit.Skill == null)
        {
            skill2.SetActive(false);
        }
        else
        {
            skill2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (skillRef == 2 && skill2.activeSelf == true && skill1.activeSelf == true)
            {
                skillRef = 0;

                skill1.transform.parent = skill1.transform.parent.parent;

                SelectedSkill = AvailableSkills[skillRef];

                skill1.transform.parent = skill2.transform.parent;

                skill1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                skill2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                skill0.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (skillRef == 0 && skill0.activeSelf == true && skill2.activeSelf == true)
            {
                skillRef = 1;

                skill2.transform.parent = skill2.transform.parent.parent;

                SelectedSkill = AvailableSkills[skillRef];

                skill2.transform.parent = skill0.transform.parent;

                skill2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                skill0.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                skill1.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (skillRef == 1 && skill1.activeSelf == true && skill0.activeSelf == true)
            {
                skillRef = 2;

                skill0.transform.parent = skill0.transform.parent.parent;

                SelectedSkill = AvailableSkills[skillRef];

                skill0.transform.parent = skill1.transform.parent;

                skill0.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                skill1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                skill2.transform.localScale = new Vector3(1, 1, 1);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (skillRef == 0 && SelectedSkill.thisUnit == PlayerUnits[0] && skill0.GetComponent<CooldownDisplay>().canUse == true)
            {
                SelectedSkill.ShootBullet();
                skill0.GetComponent<CooldownDisplay>().SkillPressed();
            }
            else if (skillRef == 1 && SelectedSkill.thisUnit == PlayerUnits[1] && skill1.GetComponent<CooldownDisplay>().canUse == true)
            {
                SelectedSkill.ShootBullet();
                skill1.GetComponent<CooldownDisplay>().SkillPressed();
            }
            else if (skillRef == 2 && SelectedSkill.thisUnit == PlayerUnits[2] && skill2.GetComponent<CooldownDisplay>().canUse == true)
            {
                SelectedSkill.ShootBullet();
                skill2.GetComponent<CooldownDisplay>().SkillPressed();
            }

        }


    }

}
