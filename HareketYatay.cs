using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketYatay : MonoBehaviour
{
    Rigidbody2D fizik;
    public float speedYatay;
    public float speedDikey;
    public float zaman;
    public bool Hareket = true;

    void Start()
    {
        fizik = GetComponent<Rigidbody2D>();
        InvokeRepeating("HareketKontrol", 0.1f, zaman);
    }
    void HareketKontrol()
    {
        speedYatay = -speedYatay;
        speedDikey = -speedDikey;

    }
   
    void Update()
    {
        if(Hareket)
        fizik.velocity = new Vector2(speedYatay, speedDikey);
    }
}
