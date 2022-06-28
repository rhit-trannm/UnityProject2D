using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QAbility : MonoBehaviour
{
    void Start()
    {
        UnityEngine.Object.Destroy(gameObject, 1f);
    }
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BaseEnemy>() != null)
        {
            other.GetComponent<BaseEnemy>().TakeDamage(30);
            Debug.Log(other.name);
        }
        else
        {
            Debug.Log(other.name);
            return;
        }
        
        
    }
}
