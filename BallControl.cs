using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BallControl : MonoBehaviour
{
    Rigidbody2D fizik;
    public float gravtyscale = 1.0f;
    bool isforce = false;
    public float speed = 250;
    public static float globalgravity = -9.8f;
    public ParticleSystem topisik;
    GameObject kamera;
    Vector3 kamerailkpos;
    Vector3 kamerasonpos;
    
    public GameObject TemasParticle;
    public GameObject LevelBitisPortal;
    public GameObject YildizTemasParticle;
    public GameObject oyunbittiparticle;
    public GameObject KazanmaParticle;
    GameObject ilerlemeSlider;
    bool SagDurum = false;
    bool SolDurum = false;
    float PortalileAradakiMesafeilk, PortalileAradakiMesafeAnlik;
    GameObject YildizMiktar;
    GameObject Mevcutlevel;
    GameObject SonrakiLevel;
    GameObject Progress;
    GameObject[] Kalpler;
    GameObject DeadMenu;
    GameObject KazanmaMenu;
    bool oyunbittimi = false;
    int KalanKalp = 3;
    float Maxİlerleme=0;
    public bool donus = false;

    void Start()
    {
        NesneleriBul();
      //  DeadMenu.transform.position = new Vector3(0, -47, 0);
       // KazanmaMenu.transform.position = new Vector3(0, -8, 0);
        DeadMenu.gameObject.SetActive(false);
        KazanmaMenu.gameObject.SetActive(false);
        fizik = GetComponent<Rigidbody2D>();
        kamerailkpos = kamera.transform.position - transform.position; //Kamera ilk pozisyon
        fizik.gravityScale = 0;
        PortalileAradakiMesafeilk = Vector3.Distance(transform.position, LevelBitisPortal.transform.position);
        //Ulaşılan en son level kayit,Menu kilitlerinin açılabilmesi için
        if (PlayerPrefs.GetInt("MaxLevel") < int.Parse(SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt("MaxLevel", int.Parse(SceneManager.GetActiveScene().name));
        }
    }
    void NesneleriBul()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        ilerlemeSlider= GameObject.FindGameObjectWithTag("Slider");
        YildizMiktar = GameObject.FindGameObjectWithTag("TextYildiz");
        Mevcutlevel = GameObject.FindGameObjectWithTag("MLevel");
        SonrakiLevel = GameObject.FindGameObjectWithTag("NLevel");
        Progress = GameObject.FindGameObjectWithTag("Progress");
        Kalpler = GameObject.FindGameObjectsWithTag("Kalp1");
        KazanmaMenu= GameObject.FindGameObjectWithTag("KazanmaMenu");
        DeadMenu= GameObject.FindGameObjectWithTag("DeadMenu");

    }
    void kamerakontrol()
    {
        
        kamerasonpos = kamerailkpos + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kamerasonpos, 0.03f);//Sinematik hareket(nereden,nereye)
    }
   
    void VeriKaydetmeislemleri()
    {
        //Sözlük yapısı ile veri oluşturma---Yoksa olustur
        if (PlayerPrefs.GetInt("YildizMiktar") == 0)
        {
            PlayerPrefs.SetInt("YildizMiktar", 0); // PlayerPrefs.SetInt("Kayit", 5);//Kayit anahtarı ile 5 değerini kaydediyoruz. veri tabanı gibi her yerden ulaşılabilir
                                                 //  PlayerPrefs.GetInt("Kayit");//5 değerini alıyoruz
                                                 //PlayerPrefs.DeleteAll();  //Bütün Kayıtları siler
                                                 // PlayerPrefs.DeleteKey("Anahtar");

        }
        
    }
    void VeritabaniUpdate()
    {

        YildizMiktar.GetComponent<Text>().text = PlayerPrefs.GetInt("YildizMiktar").ToString();
        Mevcutlevel.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        SonrakiLevel.GetComponent<Text>().text = (int.Parse(SceneManager.GetActiveScene().name) + 1).ToString();
    }
    private void FixedUpdate()
    {
        if (!oyunbittimi) { 
        kamerakontrol();
        Vector3 gravity = gravtyscale * Vector3.up * globalgravity;
        
        fizik.AddForce(gravity, ForceMode2D.Force);
        if (Input.GetKey(KeyCode.D) && fizik.velocity.x<10)
        {
             fizik.AddForce(new Vector2(17, 0));
           // fizik.velocity = new Vector2(8, fizik.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) && fizik.velocity.x >-10)
        {
            fizik.AddForce(new Vector2(-17, 0));
            //fizik.velocity = new Vector2(-8, fizik.velocity.y);

        }
        //Debug.Log(fizik.velocity.x);

        if (Input.touchCount > 0)
        {
            Touch tiklama = Input.GetTouch(0);
            Vector3 tiklama_pos = Camera.main.ScreenToWorldPoint(tiklama.position);
            if (tiklama_pos.x > transform.position.x && fizik.velocity.x < 10)
            {
                fizik.AddForce(new Vector2(17, 0));
                SagDurum = true;
                //durum = true;
            }
            else if (tiklama_pos.x < transform.position.x && fizik.velocity.x > -10)
            {
                
                fizik.AddForce(new Vector2(-17, 0));
                SolDurum = true;
            }
            else
            {
                if (SagDurum)
                {
                    fizik.AddForce(new Vector2(-45, 0));
                    SagDurum = false;
                }
                else if (SolDurum)
                {
                    fizik.AddForce(new Vector2(45, 0));
                    SolDurum = false;
                }
            }
          
          
        }
        }
    }
    void OyunBitti()
    {
        oyunbittimi = true;
        DeadMenu.gameObject.SetActive(true);
        Instantiate(oyunbittiparticle, transform.position, Quaternion.identity);

        Progress.GetComponent<Text>().text = "PROGRESS %" + (int)(Maxİlerleme * 100);
        
        this.gameObject.SetActive(false);
       


    }
    void kazanma()
    {
        oyunbittimi = true;
        KazanmaMenu.gameObject.SetActive(true);
        Instantiate(KazanmaParticle, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
    void force()
    {
        isforce = false;
        fizik.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (donus)
        {
            transform.Rotate(0, 0,-0.5f);
        }
        //Debug.Log((PortalileAradakiMesafeilk - PortalileAradakiMesafeAnlik) / PortalileAradakiMesafeilk);
        
        PortalileAradakiMesafeAnlik = Vector3.Distance(transform.position, LevelBitisPortal.transform.position);

        ilerlemeSlider.GetComponent<Slider>().value = (PortalileAradakiMesafeilk - PortalileAradakiMesafeAnlik) / PortalileAradakiMesafeilk;
        if (Maxİlerleme < (PortalileAradakiMesafeilk - PortalileAradakiMesafeAnlik) / PortalileAradakiMesafeilk)
        {
            Maxİlerleme = (PortalileAradakiMesafeilk - PortalileAradakiMesafeAnlik) / PortalileAradakiMesafeilk;
        }
        if (isforce == true)
        {
            force();
        }
        VeritabaniUpdate();
        //Debug.Log(Maxİlerleme);


    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isforce = true;
    }
    void renkdüzelt()
    {
        topisik.GetComponent<ParticleSystem>().startColor = new Color(255, 255, 255);
    }
    void kalpKapa()
    {
        if (KalanKalp >= 0)
            Kalpler[KalanKalp].gameObject.SetActive(false);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Testere" )
        {
            kamera.GetComponent<Animator>().SetTrigger("Temas");
            topisik.GetComponent<ParticleSystem>().startColor = new Color(255, 0, 0);
            Instantiate(TemasParticle, transform.position, Quaternion.identity);
            Invoke("renkdüzelt", 3);              
            if (KalanKalp >= 0)
            {
                for (int i = 0; i < KalanKalp; i++)
                {
                    Kalpler[i].GetComponent<Animator>().SetTrigger("Temas");
                }
                KalanKalp -= 1;
                Invoke("kalpKapa", 1f);                
            }
            if (KalanKalp == 0)
            {
                
                OyunBitti();

            }
            
            



        }
        if (collision.gameObject.tag == "Yukari")
        {
            if (SceneManager.GetActiveScene().name == "4")
            {
                fizik.AddForce(new Vector2(0, 425));
            }
            else
            {
                fizik.AddForce(new Vector2(0, 650));
            }
            

        }
        if (collision.gameObject.tag == "AltKontrol")
        { 
            OyunBitti();

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Meteor")
        {
            kamera.GetComponent<Animator>().SetTrigger("Temas");
            topisik.GetComponent<ParticleSystem>().startColor = new Color(255, 0, 0);
            Instantiate(TemasParticle, transform.position, Quaternion.identity);
            Invoke("renkdüzelt", 3);
            if (KalanKalp >= 0)
            {
                for (int i = 0; i < KalanKalp; i++)
                {
                    Kalpler[i].GetComponent<Animator>().SetTrigger("Temas");
                }
                KalanKalp -= 1;
                Invoke("kalpKapa", 1f);
            }
            if (KalanKalp == 0)
            {

                OyunBitti();

            }
        }
        if (collision.tag == "Yildiz")
        {
            PlayerPrefs.SetInt("YildizMiktar", PlayerPrefs.GetInt("YildizMiktar")+1);
            collision.gameObject.SetActive(false);
            Instantiate(YildizTemasParticle, transform.position, Quaternion.identity);
        }
        if (collision.tag == "BitisPortal")
        {
            kazanma();
        }
      
    }
    void anamenu()
    {
        SceneManager.LoadScene(0);
    }
}
