using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
/*    private float speed = 5;

    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float setSpeed)
    {
        speed = setSpeed;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
/*        Vector2 direction = new Vector2(transform.up.x, transform.up.y);
        rb.velocity = direction * Time.fixedDeltaTime * speed;
        Destroy(gameObject, 5);*/
    }
    void HitRegistration()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<AbstractEnemy>() != null)
        {
            collision.GetComponent<BaseEnemy>().TakeDamage(30);
            Debug.Log(collision.name);
        }
        else
        {
            Debug.Log(collision.name);
            return;
        }

/*        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
