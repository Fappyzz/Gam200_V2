using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unitf;
public class InstaWin : MonoBehaviour
{
    [SerializeField] UnitBody ub1;
    [SerializeField] UnitBody ub2;
    [SerializeField] UnitBody ub3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            DamageUnit(ub1.thisUnit, 100);
            DamageUnit(ub2.thisUnit, 100);
            DamageUnit(ub3.thisUnit, 100);
        }
    }
}
