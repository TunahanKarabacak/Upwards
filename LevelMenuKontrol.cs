using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelMenuKontrol : MonoBehaviour
{
    GameObject kamera;
    Vector3 kamerailkpos;
    bool tekrar = false;
    private void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kamerailkpos = kamera.gameObject.transform.position;
    }
    public void Tekrar()
    {
        tekrar = true;
        Invoke("tekrarla", 1.5f);
        
    }
    public void Update()
    {
        if(tekrar)
         kamera.transform.position = Vector3.Lerp(kamera.transform.position, kamerailkpos, 0.03f);//Sinematik hareket(nereden,nereye)
    }
    void tekrarla()
    {
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name));
    }
    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name)+1);
    }
}
