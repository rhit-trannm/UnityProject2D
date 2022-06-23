using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHitBox : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Take Damage!2");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Take Damage!");
            collision.gameObject.SendMessage("ApplyDamage", 10);

            UnityEngine.Object.Destroy(this, 1f);
        }
    }
}
