using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.UI.Image;


public class lightRay : MonoBehaviour
{
    [SerializeField] public Light2D light;


    private void Start()
    {
        float angle = light.pointLightOuterAngle;
        Vector2 origin = light.transform.position;
    }
    private void Update()
    {

        RaycastHit2D raycastHit2D = Physics2D.Raycast(light.transform.position, GetVectorFromAngle(light.pointLightOuterAngle), light.pointLightOuterRadius);
    }

    public Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
