using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private bool _hasEnteredCollision;

    private void FixedUpdate()
    {
        _hasEnteredCollision = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hasEnteredCollision) return;
        if(!collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.collider.transform.parent != null)
                {
                    // Get the tag of the parent GameObject
                    GameObject parentTag = contact.collider.transform.parent.gameObject;
                    if (parentTag.CompareTag("Bot"))
                    {
                        bot bot = contact.collider.transform.parent.gameObject.GetComponentInParent<bot>();
                        if (contact.collider.gameObject.CompareTag("Head"))
                        {

                            GameManager.Instance.GetHitBot(-150);
                            Debug.Log(contact.collider.gameObject);
                        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                        this.gameObject.GetComponent<Collider2D>().enabled = false;
                        _hasEnteredCollision = true;
                        Destroy(this.gameObject);
                            return;
                        }
                        else if (contact.collider.gameObject.CompareTag("Body"))
                        {
                           
                        GameManager.Instance.GetHitBot(-40);
                        Debug.Log(contact.collider.gameObject);
                        this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                        this.gameObject.GetComponent<Collider2D>().enabled = false;
                        _hasEnteredCollision = true;
                        Destroy(this.gameObject);
                            return;

                        }
                    }else if (parentTag.CompareTag("Enemy"))
                    {
                        bot bot = contact.collider.transform.parent.gameObject.GetComponentInParent<bot>();
                        if (contact.collider.gameObject.CompareTag("Head"))
                        {

                            bot.GetHit(-150);
                            Debug.Log(contact.collider.gameObject);
                            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                            this.gameObject.GetComponent<Collider2D>().enabled = false;
                            _hasEnteredCollision = true;
                            //Destroy(this.gameObject);

                        }
                        else if (contact.collider.gameObject.CompareTag("Body"))
                        {

                            bot.GetHit(-40);
                            Debug.Log(contact.collider.gameObject);
                            this.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                            this.gameObject.GetComponent<Collider2D>().enabled = false;
                            _hasEnteredCollision = true;
                            //Destroy(this.gameObject);


                        }
                    }
                    Destroy(this.gameObject);
                }
                Destroy(this.gameObject);


            }
            

        }
        
    }
}
