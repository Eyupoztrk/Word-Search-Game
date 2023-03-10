using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class word : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    public TextMeshProUGUI Word;
    public Transform pos;
    private int posInt;
    public bool isClick;
  
    void Start()
    {
        Word = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
    }
    private void Update()
    {
        setPictures(Word.text[0].ToString());
    }


    public void click()
    {
        if (!isClick)
        {
            gameManager.clickSound.Play();
            this.transform.position = gameManager.BlankObject[gameManager.index].transform.position;
            gameManager.checkString[gameManager.index] = Word.text[0];
            isClick = true;
            gameManager.index++;
            
            posInt = gameManager.index;
            
            check();

        }
        else
        {
            gameManager.clickSound1.Play();
            if (posInt == gameManager.index)
            {
                this.transform.position = pos.position;
                isClick = false;
                gameManager.index--;
                gameManager.tempIndex--;
                check();
            }
            
           

        }
        
       
       
    }

    public void check()
    {
        if(gameManager.index == gameManager.str.Length)
        {
            gameManager.isCorrect = true;
        }
    }
    public void setPictures(string letter)
    {
        switch(letter.ToUpper())
        {
            case "A":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[0].sprite;
                break;
            case "B":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[1].sprite;
                break;
            case "C":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[2].sprite;
                break;
            case "D":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[3].sprite;
                break;
            case "E":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[4].sprite;
                break;
            case "F":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[5].sprite;
                break;
            case "G":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[6].sprite;
                break;
            case "H":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[7].sprite;
                break;
            case "I":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[8].sprite;
                break;
            case "Ý":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[8].sprite;
                break;
            case "J":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[9].sprite;
                break;
            case "K":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[10].sprite;
                break;
            case "L":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[11].sprite;
                break;
            case "M":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[12].sprite;
                break;
            case "N":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[13].sprite;
                break;
            case "O":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[14].sprite;
                break;
            case "P":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[15].sprite;
                break;
            case "Q":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[16].sprite;
                break;
            case "R":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[17].sprite;
                break;
            case "S":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[18].sprite;
                break;
            case "T":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[19].sprite;
                break;
            case "U":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[20].sprite;
                break;
            case "V":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[21].sprite;
                break;
            case "W":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[22].sprite;
                break;
            case "X":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[23].sprite;
                break;
            case "Y":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[24].sprite;
                break;
            case "Z":
                gameObject.GetComponent<Image>().sprite = gameManager.LetterPictures[25].sprite;
                break;

        }
    }
}
