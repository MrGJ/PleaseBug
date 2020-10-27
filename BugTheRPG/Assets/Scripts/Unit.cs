using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;


    public int regDamage;
    public int specDamage;

    public int maxHP;
    public int currentHP;
    public bool dead;

    //Damage take functionality and checks if dead
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            dead = true;
            return true;
        }
        else
        {
            dead = false;
            return false;
        }
            
    }

}
