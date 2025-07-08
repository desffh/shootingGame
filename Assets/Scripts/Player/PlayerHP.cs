using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP
{
    private float hP = 30;

    public float HP => hP;

    public void Damage(float damage)
    {
        hP -= damage;

        if(hP <= 0)
        {
            // Á×À½
        }
    }
}
