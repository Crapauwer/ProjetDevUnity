using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(-40);
            bot.Instance.GetHit(40);
        }
    }
}
