using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using static Unitf;
using static GameData;

public class CombatBulletBody : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject HitAnim;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Light2D m_glowLight;
    public Bullet bullet;
    public bool isPlayer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBullet(Bullet bullet, bool isPlayer, bool left, bool right)
    {
        this.bullet = bullet;
        this.isPlayer = isPlayer;

        if (isPlayer)
        {
            rb.AddForce(new Vector2(0, bullet.Speed), ForceMode2D.Impulse);
            sr.color = new Color(0, 200, 255);
            m_glowLight.color = Color.cyan;
        }
        else
        {
            if (!left && !right)
            {
                rb.AddForce(new Vector2(0, -bullet.Speed), ForceMode2D.Impulse);
                sr.color = Color.red;
                m_glowLight.color = Color.red;
            }

            else if (left)
            {
                rb.AddForce(new Vector2(0.5f, -bullet.Speed), ForceMode2D.Impulse);
                sr.color = Color.red;
                m_glowLight.color = Color.red;
            }
            else if (right)
            {
                rb.AddForce(new Vector2(-0.5f, -bullet.Speed), ForceMode2D.Impulse);
                sr.color = Color.red;
                m_glowLight.color = Color.red;
            }
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
        else if (collision.GetComponent<Shield>() != null && isPlayer == false)
        {
            rb.AddForce(new Vector2(0, bullet.Speed * 2), ForceMode2D.Impulse);
            this.isPlayer = true;

            collision.gameObject.SetActive(false);
        }
        else if (collision.GetComponent<Shield>() != null && isPlayer == true)
        {
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}