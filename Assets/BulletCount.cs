using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCount : MonoBehaviour
{

    
    void FixedUpdate()
    {
        Debug.Log(shooting.instance.GetChargeur());
        Debug.Log(gameObject);
        gameObject.GetComponent<TextMeshPro>().text = shooting.instance.GetChargeur() + "";
        
    }
}
