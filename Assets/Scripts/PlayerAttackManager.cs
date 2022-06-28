using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hitboxPrefab;
    public float _AbilityQ, _AbilityE, _AbilityR;
    public GameObject EAbilityPrefab;
    public LayerMask enemyLayers;
    public Vector2 attackRange;
    public float E_AbilityRadius;

    public float attackSpeed = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            NormalAttack();
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

    }

    void NormalAttack()
    {
        Vector3 vector3 = new Vector3(3,3,0);
        //GameObject hitbox = Instantiate(hitboxPrefab, firePoint.position, firePoint.transform.rotation);
     
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(firePoint.position, attackRange,0, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<BaseEnemy>().TakeDamage(30);
            Debug.Log(enemy.name + " " + enemy.GetComponent<BaseEnemy>().Health);
        }
    }


    void QAttack()
    {

        GameObject hitbox = Instantiate(hitboxPrefab, firePoint.position, firePoint.transform.rotation);
        Rigidbody2D rb = hitbox.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * 20f, ForceMode2D.Impulse);
        
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
        Gizmos.DrawWireCube(firePoint.position, attackRange);
    }



}
