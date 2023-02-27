using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleArme : MonoBehaviour
{
    [SerializeField] Image Vandal;
    [SerializeField] Image Cut;
    [SerializeField] GameObject VandalG;
    [SerializeField] GameObject CutG;
    [SerializeField] AudioSource audioSource;

    private string[] Inventory = { "Vandal" , "Cut" };
    private static string ActiveWeapon = "Vandal";

    private void Start()
    {
        Vandal.enabled= true;
        Cut.enabled = false;
        CutG.SetActive(false);
        VandalG.SetActive(true);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ActiveWeapon != "Vandal")
            {
                MakeSound("TakeVandal");
                ActiveWeapon = UpdateCycle("Vandal");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ActiveWeapon != "Cut")
            {
                MakeSound("knifeout");
                ActiveWeapon = UpdateCycle("Cut");
            }
            
        }
    }
    private void FixedUpdate()
    {
        switch (ActiveWeapon){
            case "Vandal":
                Vandal.enabled = true;
                VandalG.SetActive(true);
                break;

            case "Cut":
                Cut.enabled = true;
                CutG.SetActive(true);
                break;
        }
        }

    public void ResetEnableIventory()
    {
        Vandal.enabled = false;
        VandalG.SetActive(false);
        Cut.enabled = false;
        CutG.SetActive(false);
    }
    public string UpdateCycle(string weap)
    {
        ResetEnableIventory();
        return weap;
    }
    public static string GetActiveWeap()
    {
        return ActiveWeapon;
    }

    public void MakeSound(string name)
    {
        audioSource.clip = Resources.Load<AudioClip>(name);
        audioSource.PlayOneShot(audioSource.clip);
    }
    }

