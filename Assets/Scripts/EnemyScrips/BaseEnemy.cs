using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : AbstractEnemy
{

    //private Pathfinding.AIDestinationSetter m_AIDestionationSet;


    private void Start()
    {
        AIPath = GetComponent<Pathfinding.AIPath>();
        Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(Player != null)
        {
            AIPath.destination = Player.transform.position;
           // m_AIDestionationSet.target = player.transform;
        }
        

    }
    public void Heal(float health)
    {
        Health += health;
        ClampHealth();
    }

    public override void TakeDamage(float dmg)
    {
        Health -= dmg;
        ClampHealth();
        if (Health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        UnityEngine.Object.Destroy(gameObject);
        Debug.Log("Enemy Die");
    }

    public override void ClampHealth()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
    }
}
