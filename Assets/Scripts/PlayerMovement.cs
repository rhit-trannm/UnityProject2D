using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CameraMovement camera;
    public Rigidbody2D rb;
    public float defaultMoveSpeed = 5f;
    float horizontalMove = 0f;

    Vector2 movement;

    private float currentMoveSpeed;
    private float dashCounter, dashCooldownCounter;
    public float dashSpeed;
    public float dashLength = 2f, dashCooldown = 1f;

    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        // (Right Arrow | D ) = 1, Left = -1;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //If dash is not on cooldown and dash is not active. Then sets value for dash.
            if(dashCooldownCounter <= 0 && dashCounter <= 0)
            {
                camera.CameraDash();
                currentMoveSpeed = dashSpeed;
                
                //dash counter is duration of dash.
                dashCounter = dashLength;
            }
        }



    }
    /*
     * Fixed Update, Works very similiar as update. It is dedicated to physics.
     * Instead of being called once every frame, its called a fixed amount of time per second.
     * 
     */
    private void FixedUpdate()
    {
        //Move Characters
        if (dashCounter > 0)
        {
            dashCounter -= Time.fixedDeltaTime;
            if(dashCounter <= 0)
            {
                currentMoveSpeed = defaultMoveSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.fixedDeltaTime;
        }
       
        //fixedDeltaTime amount of time that elapsed when the last time fixed update was called. This is so that no matter how many update was called, this is consistent with all systems.
        rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
    }
}
