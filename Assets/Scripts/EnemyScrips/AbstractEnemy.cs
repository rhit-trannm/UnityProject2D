using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
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

    public Pathfinding.AIPath AIPath
    {
        get { return aIPath; }
        set { aIPath = value; }
    }
    public GameObject Player
    {
        get { return player; }
        set { player = value; }
    }
    private Pathfinding.AIPath aIPath;
    private GameObject player;


    public abstract void Die();
    public abstract void TakeDamage(float dmg);
    public abstract void ClampHealth();

}
