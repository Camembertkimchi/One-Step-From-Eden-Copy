using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    int hp;
    int armor;
    int barrier;


    public void ApplyDamage(int damage)
    {
        if(barrier > 0)
        {
            int originalDamage = damage;
            damage -= barrier;
            barrier -= originalDamage;
            
            
        }
        if(damage < 0)
        {
            damage -= armor;
            if(damage <= 0)
            {
                hp -= 1;
            }
            else
            {
                hp -= damage;
            }
        }
        

        if(hp <= 0)
        {
            //ав╬Н╤С!
        }
    }
}
