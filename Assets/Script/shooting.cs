using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public static shooting instance;
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject CountBullet;
    public float fireRate = 0.1f;
    public int bulletCount = 1;
    public float bulletSpread = 5f;
    private float nextFireTime = 0f;
    public float bulletForce;
    private int chargeur = 25;
    private bool Rechargement;
    private bool RechargeClick = false;
    [SerializeField] Image Bullet;



    private void Start()
    {
        
        CountBullet.GetComponent<TextMeshPro>().fontSize = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if(Cursor.lockState == CursorLockMode.Locked) { 
        CountBullet.GetComponent<TextMeshPro>().text = GetChargeur() + "";
        Bullet.fillAmount = (float)chargeur / 25f;
        
        if ( Time.fixedTime >= nextFireTime && chargeur == 0 || Time.fixedTime >= nextFireTime && RechargeClick) {
            chargeur = 25;
                RechargeClick= false;
            
        }

            if (chargeur > 0)
        {
            if (Input.GetButton("Fire1") && Time.fixedTime >= nextFireTime)
            {
                nextFireTime = Time.fixedTime + fireRate;
                for (int i = 0; i < bulletCount; i++)
                {
                    // Create a new bullet object
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

                    // Generate a random angle within the spread
                    float angle = Random.Range(-bulletSpread / 2, bulletSpread / 2);

                    // Rotate the bullet by the random angle
                    bullet.transform.Rotate(0, 0, angle);

                    // Add force to the bullet in the direction it's facing
                    bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
                    Rechargement = true;
                    chargeur--;
                }
            }
        }else if(chargeur == 0 && Rechargement) {
            nextFireTime = Time.fixedTime + 2.5f;
            Rechargement= false;

        }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RechargeClick= true;
                nextFireTime = Time.fixedTime + 2.5f;
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
        return chargeur;    
    }
}
