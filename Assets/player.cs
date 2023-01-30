using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    public float damping = 0.5f;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        rb.MoveRotation(Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position));        
        rb.velocity= new Vector2(movement.x * moveSpeed * Time.fixedDeltaTime,movement.y * moveSpeed * Time.fixedDeltaTime);
        rb.drag = damping* Time.fixedDeltaTime;
    }

}

