using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public float sensitivity = 3.0f;
    public float moveSpeed = 5.0f;
    public float damping = 0.5f;

    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.forward, -mouseX);

        Vector2 movementDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * movement.normalized;

        rb.velocity = movementDirection * Time.fixedDeltaTime * moveSpeed;
        rb.angularVelocity = 0;
        rb.drag = damping * Time.fixedDeltaTime;
    }

}

