using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            NormalAttack();
        }
        
    }

    private void NormalAttack()
    {
        throw new NotImplementedException();
    }
}
