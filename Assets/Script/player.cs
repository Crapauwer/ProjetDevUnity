using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : Singleton<player>
{
    public float sensitivity = 3.0f;
    public float moveSpeed = 5.0f;
    public float damping = 0.5f;

    private Vector2 movement;
    public Rigidbody2D rb;
    CameraFollow cam = new CameraFollow();



    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
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

    public Vector3 GetPos()
    {
        return new Vector3(rb.position.x, rb.position.y,0);
    }

    public float GetRot()
    {
        return transform.rotation.eulerAngles.z;
    }

    public float GetSens()
    {
        return sensitivity;
    }
    public void SetSens(float sens)
    {
        sensitivity = sens; 
    }
}

