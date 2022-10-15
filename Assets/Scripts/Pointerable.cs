using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointerable : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //[SerializeField] Camera MainCam;
    [SerializeField] GameObject onHoverUI;
    public void OnPointerDown(PointerEventData eventData)
    {
        /*onHoverUI.SetActive(true);
        onHoverUI.transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onHoverUI.SetActive(true);
        onHoverUI.transform.position = new Vector3 (eventData.pointerCurrentRaycast.worldPosition.x + 1.5f, eventData.pointerCurrentRaycast.worldPosition.y, 10);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onHoverUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
