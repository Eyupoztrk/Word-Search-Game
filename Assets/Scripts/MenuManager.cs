using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int number;
    public Text text;
    [SerializeField]
    private GameObject MarketPanel;

    public Text ChangeWordAmount;
    public Text HintAmount;
    public Text DoubleCoinAmount;
    public Text ExtraTimeAmount;
    public Text COINS;
    public Text GEMS;

    void Start()
    {
        if (!PlayerPrefs.HasKey("ALL_COIN"))
            PlayerPrefs.SetInt("ALL_COIN", 150);
        
        if (!PlayerPrefs.HasKey("GEMS"))
            PlayerPrefs.SetInt("GEMS", 50);

        if (!PlayerPrefs.HasKey("ChangeWord"))
            PlayerPrefs.SetInt("ChangeWord", 5);
        
        if (!PlayerPrefs.HasKey("HintAmount"))
            PlayerPrefs.SetInt("HintAmount", 5);
        
        if (!PlayerPrefs.HasKey("DoubleCoinAmount"))
            PlayerPrefs.SetInt("DoubleCoinAmount", 5);
        
        if (!PlayerPrefs.HasKey("ExtraTimeAmount"))
            PlayerPrefs.SetInt("ExtraTimeAmount", 5);

        
    }


    void Update()
    {
        ChangeWordAmount.text = PlayerPrefs.GetInt("ChangeWord").ToString();
        HintAmount.text = PlayerPrefs.GetInt("HintAmount").ToString();
        DoubleCoinAmount.text = PlayerPrefs.GetInt("DoubleCoinAmount").ToString();
        ExtraTimeAmount.text = PlayerPrefs.GetInt("ExtraTimeAmount").ToString();
        COINS.text = PlayerPrefs.GetInt("ALL_COIN").ToString();
        GEMS.text = PlayerPrefs.GetInt("GEMS").ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void MarketButton()
    {
        MarketPanel.SetActive(true);
    }
    public void CloseMarketButton()
    {
        MarketPanel.SetActive(false);
    }
    public void settingsButton()
    {

    }

}
   

