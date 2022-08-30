using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStats : MonoBehaviour
{

    public GameObject _GameObjectReference;

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
        get { return MovementSpeed; }
        set { MovementSpeed = value; }
    }

    public StatusBar StatusBar;
    // Start is called before the first frame update
    void Start()
    {
        _GameObjectReference = gameObject;
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
        if(health <= 0)
        {
            Die();
        }
    }
    void Update()
    {
    }
    public void AddHealth()
    {

    }
    void Die()
    {
        Debug.Log("Enemy Die");
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
