using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float distanceBetweenStep;
    private AudioClip clip;
    private Vector3 initialPosition;
    private Vector3 initialPositionforStraf;
    private float CachePos;
    private string[] pas =  {"pas1", "pas2", "pas3", "pas4", "pas5", "pas6", "pas7" };

    void Start()
    {

        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GetPlayerSlow())
        {
            initialPosition = transform.position;
            initialPositionforStraf = transform.position;
            
        }
            if (!GameManager.Instance.GetPlayerSlow()) 
        {
            if(GameManager.Instance.GetPlayerVel() == new Vector2(0,0))
            {
                
                initialPositionforStraf = transform.position;
            }
            float distanceMoved = Vector3.Distance(transform.position, initialPosition);
            float distanceMovedForStraf = Vector3.Distance(transform.position, initialPositionforStraf);
            if (distanceMovedForStraf > distanceBetweenStep/2)
            {
                CachePos += distanceMoved;
            }
            
            initialPosition = transform.position;

            if (CachePos >= distanceBetweenStep)
            {
            string r = pas[Random.Range(0, pas.Length)];
            
            
            audioSource.clip = Resources.Load<AudioClip>(r);
            
            audioSource.Play();
            CachePos = 0;
                
            } 
        }
        
    }
}
