using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class CameraController : NetworkBehaviour
{

    public Camera Cam;
    public bool destroy;
    public void Start()
    {
        if (!IsLocalPlayer)
        {
            return;
        }

    }
        // Update is called once per frame
        void Update()
        {
            if (!IsOwner)
            {
                return;
            }
      if(GameManager.Instance.IsNewPlayerSpawn()) {
            Camera[] allCameras = FindObjectsOfType<Camera>();

            // Désactiver chaque caméra trouvée
            foreach (Camera cam in allCameras)
            {
                cam.enabled = false;
            }
            Cam.enabled = true;
        }
    



    }

    public void DestroyCam()
    {
        if(destroy) { destroy = false; } else
        {
            destroy= true;
        }
        
        gameObject.SetActive(destroy);
    }
    }


