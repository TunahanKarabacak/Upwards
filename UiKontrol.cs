using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiKontrol : MonoBehaviour
{
    [SerializeField]
    private Text YildizMiktar;
    [SerializeField]
    private GameObject Top2BuyPanel;
    [SerializeField]
    private GameObject Top3BuyPanel;
    [SerializeField]
    private GameObject Top1SelectedPanel;
    [SerializeField]
    private GameObject Top2SelectedPanel;
    [SerializeField]
    private GameObject Top3SelectedPanel;
    [SerializeField]
    private GameObject Top1SelectPanel;
    [SerializeField]
    private GameObject Top2SelectPanel;
    [SerializeField]
    private GameObject Top3SelectPanel;
    [SerializeField]
    private GameObject animKontrol;

    void Start()
    {
   
        if (PlayerPrefs.GetInt("Top2Buy") == 0)
        {
            PlayerPrefs.SetInt("Top2Buy", 0);
        }
        if (PlayerPrefs.GetInt("Top3Buy") == 0)
        {
            PlayerPrefs.SetInt("Top3Buy", 0);
        }
        if (PlayerPrefs.GetInt("MaxLevel") == 0)
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
        }
        PlayerPrefs.SetInt("YildizMiktar", 100);
        buykontrol();
        TopSecimKontrol();

    }
    void TopSecimKontrol()
    {
        if (PlayerPrefs.GetInt("TopSecim") == 0)
        {
            top1sec();
        }
        else if (PlayerPrefs.GetInt("TopSecim") == 1)
        {
            top2sec();
        }
        else if (PlayerPrefs.GetInt("TopSecim") == 2)
        {
            top3sec();
        }
    }
   public void topselectmenu()
    {
        animKontrol.GetComponent<Animator>().SetTrigger("TopSelect");
    }
   public void TopselectgeriDon(){
        animKontrol.GetComponent<Animator>().SetTrigger("TopSelectGeriDon");
    }
    public void LevelsMenu()
    {
        animKontrol.GetComponent<Animator>().SetTrigger("Levels");
    }
    public void levelsGeriDon()
    {
        animKontrol.GetComponent<Animator>().SetTrigger("LevelGeriDon");
    }
    void buykontrol()
    {
        if(PlayerPrefs.GetInt("Top2Buy") == 0)
        {
            Top2SelectedPanel.SetActive(false);
            Top2SelectPanel.SetActive(false);
            Top2BuyPanel.SetActive(true);
        }
        else
        {
            Top2BuyPanel.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Top3Buy") == 0)
        {
            Top3SelectedPanel.SetActive(false);
            Top3SelectPanel.SetActive(false);
            Top3BuyPanel.SetActive(true);
        }
        else
        {
            Top3BuyPanel.SetActive(false);
            
        }
    }
   
    void Update()
    {
        YildizMiktar.text = PlayerPrefs.GetInt("YildizMiktar").ToString();
    }
    public void Top2SatinAl()
    {
        if (PlayerPrefs.GetInt("YildizMiktar") >= 15)
        {
            PlayerPrefs.SetInt("YildizMiktar", PlayerPrefs.GetInt("YildizMiktar")-15);
            PlayerPrefs.SetInt("Top2Buy", 1);
            Top2BuyPanel.SetActive(false);
            Top2SelectPanel.SetActive(true);

            
        }
    }
    public void Top3SatinAl()
    {
        if (PlayerPrefs.GetInt("YildizMiktar") >= 25)
        {
            PlayerPrefs.SetInt("YildizMiktar", PlayerPrefs.GetInt("YildizMiktar") - 25);
            PlayerPrefs.SetInt("Top3Buy", 1);
            Top3BuyPanel.SetActive(false);
            Top3SelectPanel.SetActive(true);
        }
    }
    public void top1sec()
    {
        PlayerPrefs.SetInt("TopSecim", 0);
        Top1SelectedPanel.SetActive(true);
        Top1SelectPanel.SetActive(false);
        if(PlayerPrefs.GetInt("Top2Buy") == 0)
        {
            Top2BuyPanel.SetActive(true);
            Top2SelectedPanel.SetActive(false);
            Top2SelectPanel.SetActive(false);
        }
        else
        {
            Top2SelectPanel.SetActive(true);
            Top2BuyPanel.SetActive(false);
            Top2SelectedPanel.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Top3Buy") == 0)
        {
            Top3BuyPanel.SetActive(true);
            Top3SelectedPanel.SetActive(false);
            Top3SelectPanel.SetActive(false);
        }
        else
        {
            Top3SelectPanel.SetActive(true);
            Top3BuyPanel.SetActive(false);
            Top3SelectedPanel.SetActive(false);
        }
    }
    public void top2sec()
    {
        PlayerPrefs.SetInt("TopSecim", 1);
        Top2SelectedPanel.SetActive(true);
        Top2SelectPanel.SetActive(false);
        if (PlayerPrefs.GetInt("Top3Buy") == 0)
        {
            Top3BuyPanel.SetActive(true);
            Top3SelectedPanel.SetActive(false);
            Top3SelectPanel.SetActive(false);
        }
        else
        {
            Top3SelectPanel.SetActive(true);
            Top3BuyPanel.SetActive(false);
            Top3SelectedPanel.SetActive(false);
        }
        Top1SelectedPanel.SetActive(false);
        Top1SelectPanel.SetActive(true);
    }
    public void top3sec()
    {
        PlayerPrefs.SetInt("TopSecim", 2);
        Top3SelectedPanel.SetActive(true);
        Top3SelectPanel.SetActive(false);
        if (PlayerPrefs.GetInt("Top2Buy") == 0)
        {
            Top2BuyPanel.SetActive(true);
            Top2SelectedPanel.SetActive(false);
            Top2SelectPanel.SetActive(false);
        }
        else
        {
            Top2SelectPanel.SetActive(true);
            Top2BuyPanel.SetActive(false);
            Top2SelectedPanel.SetActive(false);
        }
        Top1SelectedPanel.SetActive(false);
        Top1SelectPanel.SetActive(true);
    }
    public void MaxLevelGit()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
    }
    public void levelegit(int index)
    {
        SceneManager.LoadScene(index);
    }
}
