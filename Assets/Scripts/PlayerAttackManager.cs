using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hitboxPrefab;
    public float _AbilityQ, _AbilityE, _AbilityR;
    public LayerMask enemyLayers;
    public Vector2 attackRange;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            NormalAttack();
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
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(firePoint.position, attackRange);
    }



}
