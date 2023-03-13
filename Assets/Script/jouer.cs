using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class jouer : MonoBehaviour
{

    [SerializeField] private Button serverBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button hostBtn;

    private void Awake()
    {

        serverBtn.onClick.AddListener(() =>
        {
            LoadHCS.server = true;
            SceneManager.LoadScene("game1v1");
            
        });
        clientBtn.onClick.AddListener(() =>    
        {
            LoadHCS.client = true;
            SceneManager.LoadScene("game1v1");
        });
        hostBtn.onClick.AddListener(() =>
        {
            LoadHCS.host = true;
            SceneManager.LoadScene("game1v1");
        });

    }
}
