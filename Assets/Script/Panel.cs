using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class Panel : NetworkBehaviour
{
    public GameObject option;
    public bool visible = false;
    public Dropdown Res;
    public AudioSource audiosoiurce;
    public Slider slider;
    public GameObject Volume;

    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (!visible)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        visible =! visible;
        option.SetActive(visible);
    }
    }

    public void SetRes()
    {
        switch (Res.value)
        {
            case 0:
                Screen.SetResolution(Screen.width, Screen.height, true); 
                break;
            case 1:
                Screen.SetResolution(Screen.width, Screen.height, true);
                break;
        }
    }

    public void SliderChange()
    {
        audiosoiurce.volume = slider.value;
        Volume.GetComponent<TextMeshPro>().text = "Volume" + (audiosoiurce.volume* 100) + "%";
    }

    public void SensChange(float sens)
    {
        GameManager.Instance.SetPlayerSens(sens, gameObject.transform.parent.transform.Find("PlayerBody").GetComponent<player>());
    }
}
