using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.GetComponent<CombatBulletBody>() != null)
        {
            if (collision.GetComponent<CombatBulletBody>().isPlayer == false)
            {
                this.gameObject.SetActive(false);
            }
        }*/
    }
}
