using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Raycast : MonoBehaviour
{
    RaycastHit hitInfo;
    public LayerMask mask;
    public GameObject Crosshair;
    private Vector2 defaultPosCross;
    public float maxRange = 30f;
    // Start is called before the first frame update
    void Start()
    {
        defaultPosCross = Crosshair.transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up,30f,mask,5f);
        if(hit.collider != null && hit.collider.tag != "Player")
        {

            Debug.DrawRay(transform.position, transform.up * hit.distance, Color.green);
            
            Crosshair.transform.position = new Vector3(hit.point.x, hit.point.y,10f);
            Debug.Log(hit.collider.tag);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * maxRange, Color.green);
            Crosshair.transform.position = (transform.position + transform.up*maxRange);
        }
        
        
            
    }
}
