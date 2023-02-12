using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : Singleton<bot>
{
    private int Health = 100;

    public void GetHit(int damage)
    {
        Health -= damage;
    }
    
    public int GetHealth() {
        Debug.Log(Health);
        return Health;
            }

}
