using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(3f, 20f)]
    [SerializeField] private float Distance;
    [SerializeField] private GameObject Camera;
    

    void Awake()
    {
        Debug.Log("caca");
        Set(Distance);
    }

    private Vector3 Change(float NewDistance)
    {
        
        Distance = NewDistance;
        
        var posplayer = player.Instance.GetPos();
        var angle = player.Instance.GetRot();
        
        var q = Quaternion.AngleAxis(angle+90,Vector3.forward);
        var Newpos = posplayer + q * Vector3.right * Distance;
        return Newpos;
    }
    
    public float Get()
    {
        return Distance;
    }

    public void Set(float NewDistance)
    {
        Camera.transform.position = Change(NewDistance);
    }

    

    
}
