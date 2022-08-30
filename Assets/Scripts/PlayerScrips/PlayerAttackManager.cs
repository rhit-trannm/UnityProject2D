using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject hitboxPrefab;
    public float _AbilityQ, _AbilityE, _AbilityR;
    public GameObject EAbilityPrefab;
    public LayerMask enemyLayers;
    public LayerMask items;


    public Vector2 attackRange;
    public float E_AbilityRadius;
    public float pickUpDistance;

    private PlayerStats _PlayerStats;
    private GameObject _CurrentGunEquipped;



    public float attackSpeed = 20f;
    // Update is called once per frame

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QAttack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            EAttack();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            PickUpWeapon();
        }

    }
    void PickUpWeapon()
    {
        Collider2D[] Items = Physics2D.OverlapBoxAll(firePoint.transform.position, attackRange, 0, items);
        
        foreach (Collider2D item in Items)
        {
            AbstractGun s = item.GetComponent<AbstractGun>();

            s.onPickUp(firePoint);
            Debug.Log(item.name);
        }

    }

    void QAttack()
    {

        GameObject hitbox = Instantiate(hitboxPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = hitbox.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.right * 20f, ForceMode2D.Impulse);
        
    }

    void EAttack()
    {
        GameObject EAbility = Instantiate(EAbilityPrefab, gameObject.transform);
        EAbility.transform.parent = gameObject.transform;

    }

    void RAttack()
    {

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(firePoint.transform.position, attackRange);
    }



}
