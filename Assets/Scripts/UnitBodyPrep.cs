using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameData;
using static Itemf;
using static GameManager;

public class UnitBodyPrep : MonoBehaviour, IPointerClickHandler
{
    public enum UnitRef { Unit0, Unit1, Unit2 };
    [SerializeField] public UnitRef thisUnitRef;

    public Unit thisUnit;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SelectingItem == true)
        {
            ConsumeItem(SelectedItem, thisUnit);

            PlayerItems.Remove(SelectedItem);
            SelectedItemBody.thisItem = null;

            SelectingItem = false;
            SelectedItem = null;
            SelectedItemBody.selected = false;
            SelectedItemBody = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (thisUnitRef == UnitRef.Unit0)
        {
            thisUnit = PlayerUnits[0];

        }
        else if (thisUnitRef == UnitRef.Unit1)
        {
            thisUnit = PlayerUnits[1];

        }
        else if (thisUnitRef == UnitRef.Unit2)
        {
            thisUnit = PlayerUnits[2];

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
