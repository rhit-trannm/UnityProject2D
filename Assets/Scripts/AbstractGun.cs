using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGun : AbstractPickUp
{
    protected GameObject firePoint;
    private float attackSpeed;
    protected bool equipped = false;

    public GameObject GetFirePoint()
    {
        return firePoint;
    }
    public void SetFirePoint(GameObject firePoint)
    {
        
    }
    public override void onPickUp(GameObject firePoint)
    {
        equipped = true;
        this.firePoint = firePoint;
        //gameObject.transform.parent = firePoint.transform;
        gameObject.transform.SetParent(firePoint.transform.parent, false);
        
    }
    public void OnDropOff()
    {
        equipped = false;
        firePoint.transform.SetParent(null);
    }
    public abstract void PrimaryAttack();
    public abstract void AlternateAttack();

}
