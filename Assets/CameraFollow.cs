using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(-5f, 5f)]
    [SerializeField] private float Distance;
    
    private Vector3 Change()
    {
        var dis = new Vector3(transform.position.x, transform.position.y + Get(), transform.position.z);
        return dis;
    }
    
    public float Get()
    {
        return Distance;
    }

    public void Set()
    {
        transform.position = Change();
    }

    public void FixedUpdate()
    {
        
    }

    public void Start()
    {
        Set();
    }
}
