using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameData;
using static GameManager;

public class PrepItemsHC : MonoBehaviour
{
    [SerializeField] Image Itemimg;
    [SerializeField] int thisItemRef;


    [SerializeField]Sprite Gun1sprite;
    [SerializeField]Sprite Gen1sprite;
    [SerializeField]Sprite Repairsprite;
    [SerializeField]Sprite Armorsprite;


    [SerializeField] ItemBody ib;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PlayerItems[thisItemRef].Name == itemBody.thisItem.Name.Contains("Single shot gun")) ;
        {
            Itemimg.sprite = Gun1sprite;
        }*/
        /*else if (PlayerItems[thisItemRef].Name == "Shield generator")
        {
            Itemimg.sprite = Gen1sprite;
        }        
        else if (PlayerItems[thisItemRef].Name == "Repair kit")
        {
            Itemimg.sprite = Repairsprite;
        }        
        else if (PlayerItems[thisItemRef].Name == "Armor")
        {
            Itemimg.sprite = Armorsprite;
        }*/
        if (ib.thisItem != null)
        {
            if (ib.thisItem.Name == "Single shot gun")
            {
                Itemimg.sprite = Gun1sprite;
            }
            else if (ib.thisItem.Name == "Shield generator")
            {
                Itemimg.sprite = Gen1sprite;
            }
            else if (ib.thisItem.Name == "Repair kit")
            {
                Itemimg.sprite = Repairsprite;
            }
            else if (ib.thisItem.Name == "Armor")
            {
                Itemimg.sprite = Armorsprite;
            }
        }
    }
}
