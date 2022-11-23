using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpUI : MonoBehaviour
{
    UnitBody body;
    [SerializeField] GameObject hpTextGO;
    TextMeshProUGUI tmpText;

    UnitBodyPrep bodyPrep;
    RectTransform bodyPrepRT;

    [SerializeField] GameObject skillGO;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<UnitBody>() != null)
        {
            body = GetComponent<UnitBody>();
        }

        if (GetComponent<UnitBodyPrep>() != null)
        {
            bodyPrep = GetComponent<UnitBodyPrep>();
            bodyPrepRT = bodyPrep.GetComponent<RectTransform>();
        }

        tmpText = hpTextGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {


        if (body != null)
        {
            if (body.thisUnit != null)
            {
                tmpText.text = string.Format("{0} / {1}", body.thisUnit.Hp.ToString(), body.thisUnit.MaxHp.ToString());

                if (body.thisUnitFaction == UnitBody.UnitFaction.Player)
                {
                    hpTextGO.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
                    skillGO.transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, 0);
                }
                else if (body.thisUnitFaction == UnitBody.UnitFaction.Enemy)
                {
                    hpTextGO.transform.position = new Vector3(transform.position.x, transform.position.y + 0.55f, 0);
                }
            }
        }

        if (bodyPrep != null)
        {
            if (bodyPrep.thisUnit != null)
            {
                tmpText.text = string.Format("{0} / {1}", bodyPrep.thisUnit.Hp.ToString(), bodyPrep.thisUnit.MaxHp.ToString());
                hpTextGO.transform.position = new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z);
            }
        }

        if (body.thisUnit.Skill == null)
        {
            skillGO.SetActive(false);
        }
        else
        {
            skillGO.SetActive(true);
        }
    }
}
