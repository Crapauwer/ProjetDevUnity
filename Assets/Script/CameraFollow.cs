using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(3f, 20f)]
    [SerializeField] private float Distance;
    [SerializeField] private GameObject Camera;
    

    void Start()
    {
        
        Set(Distance);
    }

    private Vector3 Change(float NewDistance)
    {
        
        Distance = NewDistance;
        
        var posplayer = GameManager.Instance.GetPlayerPos(gameObject.GetComponent<player>());
        var angle = GameManager.Instance.GetPlayerRot(gameObject.GetComponent<player>());
        
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
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y,-5f);
    }

    

    
}
