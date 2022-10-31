using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyImage : MonoBehaviour
{
    [SerializeField] UnitBodyPrep ubp;
    [SerializeField] Image from;
    [SerializeField] Image to;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        to.sprite = from.sprite;

        /*if (from.enabled == true)
        {
            to.enabled = true;
        }
        else if (from.enabled == false)
        {
            to.enabled = false;
        }*/
        if (ubp.thisUnit.Skill == null)
        {
            to.enabled = false;
        }
        else
        {
            to.enabled = true;
        }
    }
}
