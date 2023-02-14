using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleArme : MonoBehaviour
{
    [SerializeField] Image Vandal;
    [SerializeField] Image Cut;


    private string[] Inventory = { "Vandal" , "Cut" };
    private static string ActiveWeapon = "Vandal";

    private void Start()
    {
        Vandal.enabled= true;
        Cut.enabled = false;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActiveWeapon = "Vandal";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActiveWeapon = "Cut";
        }
    }
    private void FixedUpdate()
    {
        switch (ActiveWeapon){
            case "Vandal":
                Vandal.enabled = true;
                Cut.enabled = false;
                break;

            case "Cut":
                Vandal.enabled = false;
                Cut.enabled = true;

                break;
        }
        }

    public static string GetActiveWeap()
    {
        return ActiveWeapon;
    }


        
    }

