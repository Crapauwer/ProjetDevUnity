using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headDamage : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(-150);
            bot.Instance.GetHit(150);
        }
    }
}
