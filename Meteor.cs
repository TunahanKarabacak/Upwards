using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public GameObject particle;
    public float x, y;
    Rigidbody2D fizik;
    Vector3 firstposition;
    public float tekrarZaman=4;
    private void Start()
    {
        firstposition = transform.position;
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(new Vector2(x, y));
        InvokeRepeating("tekrar", tekrarZaman, tekrarZaman);
    }
    private void tekrar()
    {
        transform.gameObject.SetActive(true);
        fizik.velocity = new Vector2(0, 0);
        transform.position = firstposition;
        fizik.AddForce(new Vector2(x, y));


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "BulutZemin") { 
        transform.gameObject.SetActive(false);
        Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}
