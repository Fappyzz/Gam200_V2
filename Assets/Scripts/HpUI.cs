using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpUI : MonoBehaviour
{
    UnitBody body;
    [SerializeField] GameObject hpTextGO;
    TextMeshProUGUI tmpText;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<UnitBody>();
        tmpText = hpTextGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpText.text = body.thisUnit.Hp.ToString();
        if (body.thisUnitFaction == UnitBody.UnitFaction.Player)
        {
            hpTextGO.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        }
        else if (body.thisUnitFaction == UnitBody.UnitFaction.Enemy)
        {
            hpTextGO.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        }
    }
}
