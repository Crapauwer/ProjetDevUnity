using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{
    private Vector2 movement;
    public Rigidbody2D rb;
    [SerializeField] public int Health;
    public Vector3 GetPos()
    {
        return new Vector3(rb.position.x, rb.position.y, 0);
    }

    public float GetRot()
    {
        return transform.rotation.eulerAngles.z;
    }

    public void GetHit(int dmg)
    {
        Health += dmg;
    }

}
