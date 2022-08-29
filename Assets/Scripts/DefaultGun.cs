using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : AbstractGun
{
    [SerializeField]
    private GameObject bulletPrefab;

    public override void AlternateAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void PrimaryAttack()
    {
        Debug.Log("Shot1");
        GameObject hitbox = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = hitbox.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.right * 20f, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

     
    // Update is called once per frame
    void Update()
    {
        if (equipped)
        {
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            gameObject.transform.rotation = firePoint.transform.rotation;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                PrimaryAttack();
            }
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {

            }
            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }


    }

}
