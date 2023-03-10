using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public int ALL_COIN;
    public TextMeshProUGUI CoinText;
    public GameObject infoMessage;
    void Start()
    {
      
        CoinText.text = PlayerPrefs.GetInt("ALL_COIN").ToString();
    }

    
    void Update()
    {
         
    }

    public void open4Letter()
    {
        if (PlayerPrefs.GetInt("ALL_COIN") >= 75) // giriþ ücreti 75'ten fazla olmalý ki içeri girebilsin
        {
            SceneManager.LoadScene("4Letter");
            PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") - 75);
        }
        else
        {
            infoMessage.SetActive(true);
            StartCoroutine(setActiveFalse());
        }
            
       
    } 
    
    
    public void open5Letter()
    {
        if (PlayerPrefs.GetInt("ALL_COIN") >= 75) // giriþ ücreti 75'ten fazla olmalý ki içeri girebilsin
        {
            SceneManager.LoadScene("5Letter");
            PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") - 75);
        }
        else
        {
            infoMessage.SetActive(true);
            StartCoroutine(setActiveFalse());
        }
            
       
    }
    
    public void open6Letter()
    {
        if (PlayerPrefs.GetInt("ALL_COIN") >= 75) // giriþ ücreti 75'ten fazla olmalý ki içeri girebilsin
        {
            SceneManager.LoadScene("6Letter");
            PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") - 75);
        }
        else
        {
            infoMessage.SetActive(true);
            StartCoroutine(setActiveFalse());
        }
            
       
    }
    public void CloseLevelScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public IEnumerator setActiveFalse()
    {
        yield return new WaitForSeconds(1f);
        infoMessage.SetActive(false);
    }
    
}
