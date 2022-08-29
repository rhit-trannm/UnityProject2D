using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField]
    private float maxHealth = 100;
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    [SerializeField]
    private float movementSpeed = 5f;
    public float MovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    //private Pathfinding.AIDestinationSetter m_AIDestionationSet;
    private Pathfinding.AIPath aIPath;
    private GameObject player;

    private void Start()
    {
        aIPath = GetComponent<Pathfinding.AIPath>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(player != null)
        {
            aIPath.destination = player.transform.position;
           // m_AIDestionationSet.target = player.transform;
        }
        

    }
    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        UnityEngine.Object.Destroy(gameObject);
        Debug.Log("Enemy Die");
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
