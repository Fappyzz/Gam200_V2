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


    public enum UnitFaction { Player, Enemy }
    [SerializeField] public UnitFaction thisUnitFaction;
    public enum UnitRef { Unit0, Unit1, Unit2 };
    [SerializeField] public UnitRef thisUnitRef;

    public Unit thisUnit;
    Bullet thisBullet;
    public Gun thisGun;

    [SerializeField] CombatBulletBody cbd;

    public float AutoAttackTimer;

    public bool CanShoot { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

        //if (AutoAttackTimer > 0 && CurrentGameState == GameState.Combat && CanShoot == true && !thisUnit.IsDead)
        //{
        //    AutoAttackTimer -= Time.deltaTime;
        //}
        //else if (AutoAttackTimer < 0 && CurrentGameState == GameState.Combat && CanShoot == true && !thisUnit.IsDead)
        //{
        //    ShootBullet();
        //    AutoAttackTimer = thisGun.AutoAttTimer;
        //}
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
        CombatBulletBody cbd = Instantiate(this.cbd, transform.position, transform.rotation);
        if (thisUnitFaction == UnitFaction.Player)
        {
            cbd.SpawnBullet(thisBullet, true);
        }
        else
        {
            cbd.SpawnBullet(thisBullet, false);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
