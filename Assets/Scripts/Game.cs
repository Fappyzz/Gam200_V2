using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Skill testSkill;
    // Start is called before the first frame update
    void Start()
    {
        testSkill = new Skill("testskill", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            testSkill.ActivateSkill();
        }*/
    }
}
