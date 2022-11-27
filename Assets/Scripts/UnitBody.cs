using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameData;
using static Unitf;
using static Itemf;

public class UnitBody : MonoBehaviour
{

    //[SerializeField] Rigidbody2D rb;

    AudioManager audioManager;

    public enum UnitFaction { Player, Enemy }
    [SerializeField] public UnitFaction thisUnitFaction;
    public enum UnitRef { Unit0, Unit1, Unit2 };
    [SerializeField] public UnitRef thisUnitRef;

    public Unit thisUnit;
    public Bullet thisBullet;
    public Gun thisGun;

    [SerializeField] public CombatBulletBody cbd;

    public float AutoAttackTimer;

    public bool CanShoot { get; set; } = false;

    [SerializeField] GameObject shieldGO;

    IEnumerator BurstShoot(int x)
    {
        for (int i = 0; i<x; i++)
        {
            ShootBullet();
            audioManager.PlaySound("EnemyShot");
            yield return new WaitForSeconds(0.2f);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            UpdateUnitBody();
            CurrentGameState = GameState.Combat;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ShootBullet();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(thisUnit.Hp);
        }*/
        if (thisUnitFaction == UnitFaction.Enemy)
        {
            if (AutoAttackTimer > 0 && CurrentGameState == GameState.Combat && CanShoot == true && !thisUnit.IsDead)
            {
                AutoAttackTimer -= Time.deltaTime;
            }
            else if (AutoAttackTimer < 0 && CurrentGameState == GameState.Combat && CanShoot == true && !thisUnit.IsDead)
            {
                int shootAmt = Random.Range(3, 6);
                StartCoroutine(BurstShoot(shootAmt));
                AutoAttackTimer = thisGun.AutoAttTimer + Random.Range(1f,2f);
            }
        }
    }

    public void UpdateUnitBody()
    {
        
            if (thisUnitFaction == UnitFaction.Player)
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
            else if (thisUnitFaction == UnitFaction.Enemy)
            {
                if (thisUnitRef == UnitRef.Unit0)
                {
                    thisUnit = EnemyUnits[0];

                }
                else if (thisUnitRef == UnitRef.Unit1)
                {
                    thisUnit = EnemyUnits[1];

                }
                else if (thisUnitRef == UnitRef.Unit2)
                {
                    thisUnit = EnemyUnits[2];

                }
            }

            thisBullet = thisUnit.Bullet;
            thisGun = thisUnit.Gun;
            AutoAttackTimer = thisGun.AutoAttTimer;
        
    }

    public void ShootBullet()
    {
        if (thisBullet.IsShield == false && GameManager.GamePaused == false)
        {
            
            if (thisUnitFaction == UnitFaction.Player)
            {
                CombatBulletBody cbd = Instantiate(this.cbd,new Vector3(transform.position.x, transform.position.y + 0.6f), transform.rotation);
                audioManager.PlaySound("PlayerGunShot");
                cbd.transform.localScale = new Vector3(0.13f, 0.13f, 1);
                cbd.SpawnBullet(thisBullet, true);
            }
            else
            {
                CombatBulletBody cbd = Instantiate(this.cbd, new Vector3(transform.position.x, transform.position.y - 0.5f), transform.rotation);
                
                cbd.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                cbd.SpawnBullet(thisBullet, false);
            }
        }
        else if (thisBullet.IsShield == true && GameManager.GamePaused == false)
        {
            shieldGO.SetActive(true);
        }
    }

}
