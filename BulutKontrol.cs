using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulutKontrol : MonoBehaviour
{
    Animator animkontrol;
    public ParticleSystem patlama;
    public bool Buyukucul = false;
    public bool TemastaKucul = false;
    public float BeklemeZaman = 1.5f;
    public float TekrarlamaZaman = 3f;

    void Start()
    {
        //StartCoroutine(fonksiyon());
        animkontrol = GetComponent<Animator>();
        patlama.Stop();
        if (Buyukucul)
            InvokeRepeating("buyumeKontrol", 1, TekrarlamaZaman);

    }

  /*  IEnumerator delay(float time)
    {

        yield return fonksiyon();
    }

    IEnumerator fonksiyon()
    {
        while (true)
        {
            Debug.Log("Çalıştı");
            yield return new WaitForSeconds(1f);
        }
    }*/

    void temas()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    public void patlamaPlay()
    {
        patlama.Play();
    }
    void buyumeKontrol()
    {
        kucul();
        Invoke("buyu", BeklemeZaman);

    }
    void buyu()
    {
        patlamaPlay();
        animkontrol.SetTrigger("buyu");
    }
    void kucul()
    {
        patlamaPlay();
        animkontrol.SetTrigger("kucul");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //animkontrol.SetTrigger("Temas");
        transform.localScale = new Vector3(0.41f, 0.41f, 0.41f);
        Invoke("temas", 1.5f);
        patlamaPlay();
        if (TemastaKucul)
        {
            kucul();
        }
    }
}
