using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    [SerializeField]
    private Button coinButton;
    [SerializeField]
    private int extraTime;
    public Text[] hintTexts;
    int tempIndex;
    [SerializeField]
    private GameObject infoPanel;
    char[] charArray;

    public GameObject doubleCoinText;
    public GameObject extraTimeText;


   

    public void AddExtraTime()
    {
        StartCoroutine(ShowAndClose(extraTimeText));
        if (PlayerPrefs.GetInt("ExtraTimeAmount") > 0)
        {
            gameManager.successSound1.Play();
            gameManager.addTime(extraTime);
            PlayerPrefs.SetInt("ExtraTimeAmount", PlayerPrefs.GetInt("ExtraTimeAmount") - 1);
        }
        else
            StartCoroutine(ShowAndClose(infoPanel));

    }

    public void doubleCoin()
    {
        doubleCoinText.SetActive(true);
        if (PlayerPrefs.GetInt("DoubleCoinAmount") > 0)
        {
            gameManager.successSound1.Play();
            gameManager.cointAmount *= 2;
            gameManager.coinText.text = "+"+gameManager.cointAmount.ToString();
            coinButton.interactable = false;
            PlayerPrefs.SetInt("DoubleCoinAmount", PlayerPrefs.GetInt("DoubleCoinAmount") - 1);
        }
        else
            StartCoroutine(ShowAndClose(infoPanel));

    }
   
    public void hintLetter()
    {
        if (PlayerPrefs.GetInt("HintAmount") > 0)
        {
            gameManager.successSound1.Play();
            stringToArray();
            
            for(int i =0;i<charArray.Length;i++)
            {
                hintTexts[i].text = charArray[i].ToString();
            }
          
            PlayerPrefs.SetInt("HintAmount", PlayerPrefs.GetInt("HintAmount") - 1);
        }
        else
            StartCoroutine(ShowAndClose(infoPanel));

    }
    public void stringToArray()
    {
        charArray = gameManager.str.ToCharArray();
        Debug.Log(gameManager.str);
    }
    public void resetHint()
    {
        tempIndex = 0;
        foreach (var item in hintTexts)
        {
            item.text = null;
        }
      

    }

    public void changeWord()
    {

        if(PlayerPrefs.GetInt("ChangeWord")>0)
        {
            gameManager.successSound1.Play();
            gameManager.ResetWords();
            gameManager.getOtherWord();
            resetHint();
            PlayerPrefs.SetInt("ChangeWord", PlayerPrefs.GetInt("ChangeWord") - 1);
        }
        else
            StartCoroutine(ShowAndClose(infoPanel));

    }

    public IEnumerator ShowAndClose(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
