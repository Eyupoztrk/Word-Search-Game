using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketMenu : MonoBehaviour
{

    public AudioSource succesSound;
    public AudioSource faultSound;

    public GameObject successPanel;
    public GameObject faultPanel;
    

    

    #region Buying Coins

    public void buy100Coin()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") +100);
    }
    
    public void buy500Coin()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") +500);
    }
    
    public void buy2500Coin()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") +2500);
    }
    
    public void buy5000Coin()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") +5000);
    }
    #endregion



    #region Buying Gems

    public void buy10Gems()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") + 10);
    }
    public void buy250Gems()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") + 250);
    }
    public void buy500Gems()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") + 500);
    }
    public void buy1500Gems()
    {
        succesSound.Play();
        StartCoroutine(showInfo(successPanel));
        PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") + 1500);
    }


    #endregion 


    #region Buying Helping

    public void buyExtraTime()
    {
        if (PlayerPrefs.GetInt("GEMS") >= 50)
        {
            succesSound.Play();
            StartCoroutine(showInfo(successPanel));
            PlayerPrefs.SetInt("ExtraTimeAmount", PlayerPrefs.GetInt("ExtraTimeAmount") + 10);
            PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") - 50);
        }
        else
            StartCoroutine(showInfo(faultPanel));
        
    }
    
    public void buyChangeWord()
    {
        if (PlayerPrefs.GetInt("GEMS") >= 50)
        {
            succesSound.Play();
            StartCoroutine(showInfo(successPanel));
            PlayerPrefs.SetInt("ChangeWord", PlayerPrefs.GetInt("ChangeWord") + 15);
            PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") - 50);
        }
        else
            StartCoroutine(showInfo(faultPanel));
    }
    
    public void buyDoubleCoin()
    {
         if (PlayerPrefs.GetInt("GEMS") >= 50)
         {
            succesSound.Play();
            StartCoroutine(showInfo(successPanel));
            PlayerPrefs.SetInt("DoubleCoinAmount", PlayerPrefs.GetInt("DoubleCoinAmount") + 10);
            PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") - 50);
        }
        else
            StartCoroutine(showInfo(faultPanel));
    }
    
    public void BuyHint()
    {
          if (PlayerPrefs.GetInt("GEMS") >= 50)
          {
            succesSound.Play();
            StartCoroutine(showInfo(successPanel));
            PlayerPrefs.SetInt("HintAmount", PlayerPrefs.GetInt("HintAmount") +50);
            PlayerPrefs.SetInt("GEMS", PlayerPrefs.GetInt("GEMS") - 50);
          }
           else
            StartCoroutine(showInfo(faultPanel));
    }

    #endregion

    public IEnumerator showInfo(GameObject panel)
    {
        if (panel == faultPanel)
            faultSound.Play();
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(false);

    }
}
