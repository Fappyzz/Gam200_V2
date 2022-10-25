using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Pointerable : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] Camera MainCam;
    [SerializeField] GameObject onHoverUI;
    TextMeshProUGUI onHoverUIText;
    bool popUp = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        /*onHoverUI.SetActive(true);
        onHoverUI.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<UnitBodyPrep>() != null)
        {
            onHoverUIText.text = eventData.pointerCurrentRaycast.gameObject.GetComponent<UnitBodyPrep>().thisUnit.Name.ToString();
            popUp = true;
        }

        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemBody>() != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemBody>().thisItem != null)
            {
                onHoverUIText.text = eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemBody>().thisItem.Desc.ToString();
                popUp = true;
            }
        }

        if (popUp)
        {
            onHoverUI.SetActive(true);
            onHoverUI.transform.position = new Vector3 (eventData.pointerCurrentRaycast.worldPosition.x + 1.5f, eventData.pointerCurrentRaycast.worldPosition.y, 10);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onHoverUI.SetActive(false);
        popUp = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        onHoverUIText = onHoverUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
