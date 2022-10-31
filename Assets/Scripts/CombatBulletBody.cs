using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unitf;

public class CombatBulletBody : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject HitAnim;

    Bullet bullet;
    bool isPlayer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBullet(Bullet bullet, bool isPlayer)
    {
        this.bullet = bullet;
        this.isPlayer = isPlayer;

        if (isPlayer)
        {
            rb.AddForce(new Vector2(0, bullet.Speed), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(0, -bullet.Speed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<UnitBody>() != null)
        {
            
            if (isPlayer && collision.GetComponent<UnitBody>().thisUnitFaction == UnitBody.UnitFaction.Enemy)
            {
                Instantiate(HitAnim, transform.position, transform.rotation);
                DamageUnit(collision.GetComponent<UnitBody>().thisUnit, bullet);

                Destroy(this.gameObject);
            }
            else if (!isPlayer && collision.GetComponent<UnitBody>().thisUnitFaction == UnitBody.UnitFaction.Player)
            {
                Instantiate(HitAnim, transform.position, transform.rotation);
                DamageUnit(collision.GetComponent<UnitBody>().thisUnit, bullet);

                if (collision.GetComponent<UnitBody>().thisUnit.Hp <= 0)
                {
                    DamageHeat(bullet);
                }

                Destroy(this.gameObject);
            }       
        }
        else if (collision.GetComponent<CombatBulletBody>() != null)
        {
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}