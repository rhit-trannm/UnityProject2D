using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform player;
    private float ActiveSmoothSpeed = 0.01f;
    public float DefaultSmoothSpeed = 0.01f;
    public float CameraDashSpeed = 0.05f;
    private float cameraDashCounter, dashCooldownCounter;
    public Vector3 offset;

    //Runs after Update, fixes race condition with player.
    void FixedUpdate()
    {

        if (cameraDashCounter > 0)
        {
            cameraDashCounter -= Time.fixedDeltaTime;
            if (cameraDashCounter <= 0)
            {
                ActiveSmoothSpeed = DefaultSmoothSpeed;
                dashCooldownCounter = playerMovement.dashCooldown;
            }
        }
        if (dashCooldownCounter > 0)
        {
            dashCooldownCounter -= Time.fixedDeltaTime;
        }

        Debug.Log(ActiveSmoothSpeed.ToString());
        //Linear Interpolation, smooth A to B.
        Vector3 smoothPostition = Vector3.Lerp(transform.position, player.position, ActiveSmoothSpeed);

        transform.position = smoothPostition + offset;
    }
    public void CameraDash()
    {
        ActiveSmoothSpeed = CameraDashSpeed;
        cameraDashCounter = playerMovement.dashLength;
    }
}
