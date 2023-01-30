using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class mouse : MonoBehaviour
{


    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Rotate the player object to look at the mouse position
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
    }
}






