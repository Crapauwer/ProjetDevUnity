using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public float sensitivity = 3.0f;
    public float moveSpeed = 3000f;
    public float moveSpeedCut = 3800f;
    public float moveSpeedSlowCut = 3000f;
    public float moveSpeedSlow = 600f;
    public float damping = 0.5f;

    private bool slow;
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
        
        if(Cursor.lockState == CursorLockMode.Locked)
        {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(Vector3.forward, -mouseX);

        Vector2 movementDirection = Quaternion.Euler(0, 0, transform.eulerAngles.z) * movement.normalized;

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

    public bool GetSlowPlayer()
    {
        return slow;
    }
}

