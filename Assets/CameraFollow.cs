using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform player;
    [SerializeField] private float threshold;

    void FixedUpdate()
    {
        
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 TargetPos = (player.position + mousePosition)/2f;
        TargetPos.x = Mathf.Clamp(TargetPos.x, -threshold + player.position.x, threshold + player.position.x);
        TargetPos.y = Mathf.Clamp(TargetPos.y, -threshold + player.position.y, threshold + player.position.y);
        this.transform.position = TargetPos;
    }
}
