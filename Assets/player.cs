using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    public float stopThreshold = 0.0f;
    public float distance = 0.5f;
    public LayerMask wall;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        rb.MoveRotation(Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position));

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction = direction.normalized;

        Vector2 targetPosition = rb.position + direction * moveSpeed * Time.deltaTime;
        rb.MovePosition(targetPosition);
    }

}

