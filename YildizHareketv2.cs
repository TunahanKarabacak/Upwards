using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YildizHareketv2 : MonoBehaviour
{
    Rigidbody2D fizik;
    public float gravtyscale = 1.0f;
    bool isforce = false;
    public float speed = 9;
    public static float globalgravity = -9.8f;
    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        fizik.gravityScale = 0;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.4f));
        Vector3 gravity = gravtyscale * Vector3.up * globalgravity;
        fizik.AddForce(gravity, ForceMode2D.Force);
        if (isforce == true)
        {
            force();
        }
    }
    void force()
    {
        isforce = false;
        fizik.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulutZemin") { 
        isforce = true;
        BulutKontrol kod = collision.gameObject.GetComponent<BulutKontrol>();
        kod.patlamaPlay();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulutZemin")
        {
            isforce = true;
            BulutKontrol kod = collision.gameObject.GetComponent<BulutKontrol>();
            kod.patlamaPlay();
        }
    }
}
