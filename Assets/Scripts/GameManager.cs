using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    private char[] letters;
    public char[] checkString;
    public GameObject[] BlankObject;
    public GameObject[] Buttons;
    public GameObject LOSE_PANEL;
    public HelpingMenu helpingMenu;

    public SpriteRenderer[] LetterPictures;
    bool isEqual=true;
    public bool isCorrect;
    public string str;
    public string Turkishstr;
    public int index=0;
    public int tempIndex = 0;

    public int TIME;
    public int ALL_COIN;
    public int EARNED_COIN;
    public int cointAmount;
    private int Timecounter;


    public TextMeshProUGUI TimeText;
    public Text turkhisLetter;
    public TextMeshProUGUI earnedCointText;

    public GameObject Time5Text;
    public TextMeshProUGUI coinText;

    

    private bool timeFinish;
   

    public TextMeshProUGUI[] texts;
    public Data data;

    [Header("SOUNDS")]
    public AudioSource clickSound;
    public AudioSource clickSound1;
    public AudioSource successSound;
    public AudioSource gameOverSound;
    public AudioSource successSound1;
    public AudioSource wrongSound;
    public AudioSource backgroundSound;

    [Header("SOUNDS BUTTONS")] 
    public GameObject soundOffButton;
    public GameObject soundOnButton;

    [Header("ADS")]
    public AdManager adManager;

    private void Awake()
    {
        backgroundSound.Play();
        checkString = new char[str.Length];
        getOtherWord(); // random kelimeler getirir
    }

    void Start()
    {
        coinText.text = "+"+cointAmount.ToString();
        EARNED_COIN = 0;
        StartCoroutine(getTime());// zamaný baþlatýr
        Debug.Log(str);
        //createLetters(str);
    }

    void Update()
    {
       
        

       if(isCorrect)
        {
            check();
            isCorrect = false;
        }

       if(timeFinish) // gameOver 
        {
            gameOverSound.Play();
            backgroundSound.Pause();
            Debug.Log("zaman bitti!!!");
            timeFinish = false;
            ALL_COIN += EARNED_COIN;
           

            OpenLosePanel();
        }


    }

    private void check() // girdiðimiz kelime verilen kelimeyle uyuþup uyþmadýðýný kontrol eder
    {
        isEqual = true;
       
        for (int i = 0; i < checkString.Length; i++)
         {
             if (checkString[i] != str[i])
                 isEqual = false;
         }



        if (isEqual)
            win();
        else
        {
            wrongSound.Play();
            Debug.Log("Eþit deðil");
            ResetWords();

        }
           
    }

   

    public void createLetters(string str) // harfleri oluþturur
    {
        letters = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            letters[i] = str[i];
            
        }
        
    }

    void Shuffle(char[] a) // kelimlerin harflerinin yerini deðiþtirir
    {
        for (int i = a.Length-1; i > 0; i--)
        {
            int rnd = Random.Range(0, i);

            char temp = a[i];

            a[i] = a[rnd];
            a[rnd] = temp;
        }
        for (int i = 0; i < str.Length; i++)
        {
            texts[i].text = a[i].ToString();
        }
       
    }

    public void ResetWords() // kelimelerin pozisyonlarýný ilk hallerine döndürür
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].transform.position = Buttons[i].GetComponent<word>().pos.transform.position;
            Buttons[i].GetComponent<Image>().color = Color.red;
            Buttons[i].GetComponent<word>().isClick= false;
            StartCoroutine(setWhite());
        }
        checkString = new char[str.Length];
        index = 0;
      
        
    }

    IEnumerator setWhite() // buttonlarýn rengini beyaz yapar (butonlar --> kelimeler)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Buttons.Length; i++)
        {
            
            Buttons[i].GetComponent<Image>().color = Color.white;
            
        }
    }
    public void win() // kazandýðýmýzda çalýþan fonksiyondur
    {
        successSound.Play();
        StartCoroutine(ShowAndClose());
        helpingMenu.resetHint();
        for (int i = 0; i < str.Length; i++)
        {
            Buttons[i].GetComponent<Image>().color = Color.green;
        }
        
        addTime(5);
        addCoin(cointAmount);
        StartCoroutine(waitForWin());
        
    }

    
    public IEnumerator waitForWin()
    {
        yield return new WaitForSeconds(0.7f);
        getOtherWord(); // kelimeyi doðru bildik, baþka bir kelimeyi getirir
    }

    public IEnumerator getTime() // zamaný belirler
    {
        
        while(true)
        {
            yield return new WaitForSeconds(1f);
            TIME -= 1;
            TimeText.text = TIME.ToString();
            Timecounter += 1;
            if (TIME ==0 )
            {
                timeFinish = true;
                break;
               
            }
                

        }
        

    }

    public void addTime(int timeAmount)
    {
        TIME += timeAmount;
    }

    public void addCoin(int coinAmount)
    {
        EARNED_COIN += coinAmount;
        earnedCointText.text = EARNED_COIN.ToString();
    }
   

    public void getOtherWord()// türkçe ve ingilizce kelimeleri getirir
    {
        
        str = data.getRandomWord().ToUpper();
        turkhisLetter.text = data.getTurkhisRandomWord().ToUpper();
        checkString = new char[str.Length];
        createLetters(str);
        Shuffle(str.ToCharArray());
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].transform.position = Buttons[i].GetComponent<word>().pos.transform.position;
            Buttons[i].GetComponent<Image>().color = Color.white;
            Buttons[i].GetComponent<word>().isClick = false;
            
        }
        checkString = new char[str.Length];
        index = 0;
        
    }
    public IEnumerator ShowAndClose()
    {
        coinText.gameObject.SetActive(true);
        Time5Text.SetActive(true);
        yield return new WaitForSeconds(1f);
        coinText.gameObject.SetActive(false);
        Time5Text.SetActive(false);
    }

    #region LOSE PANEL

    public void OpenLosePanel()
    {
        LOSE_PANEL.SetActive(true);
        StartCoroutine(Counter());
    }
    [Header("LOSE PART")]
    bool equal = true;
    public TextMeshProUGUI counterText;
    public GameObject noThanksButton;
    int counter=2;

    public void rewardButton()
    {
        adManager.LoadInerstitialAd();
      
    }

    public void Reward()
    {
        helpingMenu.resetHint();
        backgroundSound.Play();
        gameOverSound.Pause();
        LOSE_PANEL.SetActive(false);
        ResetWords();
        getOtherWord();
        TIME = 10;
        StartCoroutine(getTime());
        adManager.isComplete = false;
    }
    public void noThanks()
    {
        PlayerPrefs.SetInt("ALL_COIN", PlayerPrefs.GetInt("ALL_COIN") + EARNED_COIN); // Kazanýlan coinleri kaydetme
        SceneManager.LoadScene("LevelSelect");
    }
    public IEnumerator Counter()
    {
        while(equal)
        {
            yield return new WaitForSeconds(1);
            counterText.text = counter.ToString();
            counter--;
            if (counter == -1)
            {
                equal = false;
                noThanksButton.SetActive(true);
            }
        }
        
    }




    #endregion

    public void soundOn()
    {
        soundOffButton.SetActive(false);
        soundOnButton.SetActive(true);
        backgroundSound.Play();
    }

    public void soundOff()
    {
        soundOffButton.SetActive(true);
        soundOnButton.SetActive(false);
        backgroundSound.Pause();
    }




}
