using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaslangicPortal : MonoBehaviour
{
    public GameObject[] toplar;
    GameObject kamera;
    Animator animKontrol;
    private static BaslangicPortal instance;

    private void Awake()
    {

        if (instance != null)
        {
            start1();
            Destroy(gameObject);
        }
        else
        {
            start1();
            this.gameObject.SetActive(true);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
    }
    void start1()
    {

        kamera = GameObject.FindGameObjectWithTag("MainCamera");

        animKontrol = GetComponent<Animator>();


        //Veri Tabanı Olusturma
        if (PlayerPrefs.GetInt("TopSecim") == 0)
        {
            PlayerPrefs.SetInt("TopSecim", 0);
        }
        Olustur();
    }
    void Olustur()
    {
        kamera.GetComponent<Animator>().SetTrigger("Baslangic");
        Instantiate(toplar[PlayerPrefs.GetInt("TopSecim")], transform.position, Quaternion.identity);
        Invoke("bitis", 1);
    }
    void bitis()
    {
        animKontrol.SetTrigger("Bitis");
        //this.gameObject.SetActive(false);
        //Destroy(this.gameObject, 1f);
    }
}
