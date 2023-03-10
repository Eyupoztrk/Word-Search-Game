using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class Data : MonoBehaviour
{

    public string[] letters;
    public string[] turkhisLetters;

    string filePath;
    string turkhisFilePath;
    int index;
    public TextAsset text;
    public TextAsset text2;
    

    private void Awake()
    {

        filePath = "Assets/Datas/5_word.txt";
        turkhisFilePath = "Assets/Datas/5_Kelime.txt";
        ReadString();
        ReadTurkhisString();
    }

    
    public void ReadString()
    {
        letters = text.text.Split("\r\n");
       
        //letters = File.ReadAllLines(filePath);
    }
    
    public void ReadTurkhisString()
    {
        //turkhisLetters = File.ReadAllLines(turkhisFilePath);
        turkhisLetters = text2.text.Split("\r\n");
    }

    public string getRandomWord()
    {
         index = Random.Range(0, letters.Length);
        return letters[index];
    }
    public string getTurkhisRandomWord()
    {
       // int index = Random.Range(0, letters.Length);
        return turkhisLetters[index];
    }


    

   
}
