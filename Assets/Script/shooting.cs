using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Globalization;
using Unity.Netcode;

public class shooting : NetworkBehaviour
{
    public static shooting instance;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject CountBullet;
    public float fireRate = 0.1f;
    public int bulletRafale = 1;
    public float bulletSpread = 200f;
    private float nextFireTime = 0f;
    public float bulletForce;
    private float TimeReload = 2.5f;
    private int chargeur = 25;
    private int MaxChargeur = 25;
    private bool Rechargement;
    private bool RechargeClick = false;
    public Image Bullet;
    public Image RechargementCircle;
    public AudioSource audioSource;
    Dictionary<string, List<float>> WeaponStats = new Dictionary<string, List<float>>();

    
    private void Start()
    {
        WeaponStats.Add("Vandal", new List<float>() { 2.5f, 0.1f,25f,25f});
        WeaponStats.Add("Cut", new List<float>() { 0.6f, 0.6f ,1f,1f});


    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsOwner)
        {
            return;
        }

        fireRate = WeaponStats[CycleArme.GetActiveWeap()][1];
        TimeReload = WeaponStats[CycleArme.GetActiveWeap()][0];
        chargeur = (int)WeaponStats[CycleArme.GetActiveWeap()][3];
        MaxChargeur = (int)WeaponStats[CycleArme.GetActiveWeap()][2];
        RechargementCircle.enabled = false;
        if (Cursor.lockState == CursorLockMode.Locked) {
            for (int i = 0;i < CountBullet.GetComponents<Component>().Length; i++)
            {
               
            }
            
        CountBullet.GetComponent<TextMeshProUGUI>().text = GetChargeur() + "";
        Bullet.fillAmount = (float)chargeur / MaxChargeur;
            if (RechargeClick || chargeur == 0) {
               
                RechargementCircle.enabled= true;
                RechargementCircle.fillAmount = (TimeReload-(nextFireTime-Time.fixedTime))/TimeReload;
            }

            

        if ( Time.fixedTime >= nextFireTime && chargeur == 0 || Time.fixedTime >= nextFireTime && RechargeClick) {
                WeaponStats[CycleArme.GetActiveWeap()][3] = MaxChargeur;
                RechargeClick= false;
            
        }

            if (chargeur > 0)
        {
            if (Input.GetButton("Fire1") && Time.fixedTime >= nextFireTime)
            {
                nextFireTime = Time.fixedTime + fireRate;
                for (int i = 0; i < bulletRafale; i++)
                {
                        UpdateSoundWeap(CycleArme.GetActiveWeap());
                        audioSource.PlayOneShot(audioSource.clip);

                        if (CycleArme.GetActiveWeap() != "Cut")
                        {
                            // Create a new bullet object
                            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                            bullet.GetComponent<NetworkObject>().Spawn(true);

                            float angle;

                            
                            if (GameManager.Instance.GetPlayerMov(gameObject.GetComponent<player>()).x > 0.3f || GameManager.Instance.GetPlayerMov(gameObject.GetComponent<player>()).x < -0.3f || GameManager.Instance.GetPlayerMov(gameObject.GetComponent<player>()).y > 0.3f || GameManager.Instance.GetPlayerMov(gameObject.GetComponent<player>()).y < -0.3f)
                            {
                                angle = Random.Range(-bulletSpread, bulletSpread);
                            }
                            else
                            {
                                angle = 0;
                            }
                            
                            // Rotate the bullet by the random angle
                            bullet.transform.Rotate(0, 0, angle);
                            Vector2 directionBullet = bullet.transform.up;
                            // Add force to the bullet in the direction it's facing
                            bullet.GetComponent<Rigidbody2D>().AddForce(directionBullet * bulletForce, ForceMode2D.Impulse);
                            


                        }
                        
                    Rechargement = true;
                        chargeur--;
                        WeaponStats[CycleArme.GetActiveWeap()][3] = chargeur ;
                }
            }
        }else if(chargeur == 0 && Rechargement) {
            nextFireTime = Time.fixedTime + TimeReload;
            Rechargement= false;

        }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RechargeClick= true;
                nextFireTime = Time.fixedTime + TimeReload;
                Rechargement = false;
            }

        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    public int GetChargeur()
    {
        return (int)WeaponStats[CycleArme.GetActiveWeap()][3];    
    }

    public void UpdateSoundWeap(string wep)
    {
        switch (wep)
        {
            case "Vandal":
                audioSource.clip = Resources.Load<AudioClip>("VandalTap");
                break;

            case "Cut":
                audioSource.clip = Resources.Load<AudioClip>("Cut"+Random.Range(1,6));
                break;
        }
        
    }
    

}
