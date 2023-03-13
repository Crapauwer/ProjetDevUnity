using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;

public class player : NetworkBehaviour
{
    public float sensitivity = 10f;
    public float sensitivityMovement = 3.0f;
    public float moveSpeed = 3000f;
    public float moveSpeedCut = 3800f;
    public float moveSpeedSlowCut = 3000f;
    public float moveSpeedSlow = 600f;
    public float damping = 0.5f;

    private bool slow = false;
    private Vector2 movement;
    public Rigidbody2D rb;
    CameraFollow cam;



    private void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!IsOwner)
        {
            return; }
        
  
        if (Cursor.lockState == CursorLockMode.Locked)
        {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
            
            float inputMagnitude = Mathf.Clamp(movement.magnitude, 0f, 1f);
            float targetMagnitude = Mathf.Lerp(0f, 1f, Mathf.Pow(inputMagnitude, sensitivityMovement));

            //movement.Normalize();
            



            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.forward, -mouseX);

        Vector2 movementDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * movement.normalized * targetMagnitude;

            if(Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                
                slow= true;
                
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                slow = false; 
            }
            
            if (slow) {
                if (CycleArme.GetActiveWeap() == "Vandal")
                {
                    rb.velocity = movementDirection * Time.fixedDeltaTime * moveSpeedSlow;
                    
                }
                else if (CycleArme.GetActiveWeap() == "Cut")
                {
                    rb.velocity = movementDirection * Time.fixedDeltaTime * moveSpeedSlowCut;
                    
                }
                 } else
            {
                if (CycleArme.GetActiveWeap() == "Vandal")
                {
                    rb.velocity = movementDirection * Time.fixedDeltaTime * moveSpeed;
                    
                }
                else if (CycleArme.GetActiveWeap() == "Cut")
                {
                    rb.velocity = movementDirection * Time.fixedDeltaTime * moveSpeedCut;
                    
                }
                
            }
            
            rb.angularVelocity = 0;
            rb.drag = damping * Time.fixedDeltaTime;
        }
    }

    public Vector2 GetAxis()
    {
        return movement;
    }

    public Vector2 GetVel()
    {
        return rb.velocity;
    }

    public Vector3 GetPos()
    {
        return new Vector3(rb.position.x, rb.position.y,0);
    }

    public Vector2 GetPos2()
    {
        return new Vector2(rb.position.x, rb.position.y);
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

    public bool GetSlowPlayer()
    {
        return slow;
    }
}

