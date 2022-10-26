using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] UnitBody unit0;
    [SerializeField] UnitBody unit1;
    [SerializeField] UnitBody unit2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UseSkill();
    }
    private void UseSkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unit0.thisUnit.Skill.ActivateSkill();
            unit0.ShootBullet();
            Debug.Log("unit 0 using skill");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unit1.thisUnit.Skill.ActivateSkill();
            Debug.Log("unit 1 using skill");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            unit2.thisUnit.Skill.ActivateSkill();
            Debug.Log("unit 2 using skill");
        }
    }

}
