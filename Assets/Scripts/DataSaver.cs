using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using UnityEngine.UI;
using TMPro;

public class DataSaver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;
    public void Start()
    {
        scoreText.text = string.Format("High score: {0}:{1}\n" +
                                        "Second High Score: {2}:{3}\n" +
                                        "Third High Score: {4}:{5}", 
                       PlayerPrefs.GetInt("first_int"), PlayerPrefs.GetString("first_string"), //HighScore 1 values
                       PlayerPrefs.GetInt("second_int"), PlayerPrefs.GetString("second_string"), //HighScore 2 values
                       PlayerPrefs.GetInt("third_int"), PlayerPrefs.GetString("third_string")); //HighScore 3 values
        scoreText2.text ="Your Score: " + MySharedData.GetName() + ":" + MySharedData.GetIntermediateScore();
                       
    }
    static public void Save()
    {


        if (MySharedData.GetIntermediateScore() > PlayerPrefs.GetInt("first_int"))
        {
            PlayerPrefs.SetInt("third_int", PlayerPrefs.GetInt("second_int"));
            PlayerPrefs.SetString("third_string", PlayerPrefs.GetString("second_string"));

            PlayerPrefs.SetInt("second_int", PlayerPrefs.GetInt("first_int"));
            PlayerPrefs.SetString("second_string", PlayerPrefs.GetString("first_string"));

            PlayerPrefs.SetInt("first_int", MySharedData.GetIntermediateScore());
            PlayerPrefs.SetString("first_string", MySharedData.GetName());
        }
        else if (MySharedData.GetIntermediateScore() > PlayerPrefs.GetInt("second_int"))
        {
            PlayerPrefs.SetInt("third_int", PlayerPrefs.GetInt("second_int"));
            PlayerPrefs.SetString("third_string", PlayerPrefs.GetString("second_string"));

            PlayerPrefs.SetInt("second_int", MySharedData.GetIntermediateScore());
            PlayerPrefs.SetString("second_string", MySharedData.GetName());
        }
        else if (MySharedData.GetIntermediateScore() > PlayerPrefs.GetInt("third_int"))
        {
            PlayerPrefs.SetInt("third_int", MySharedData.GetIntermediateScore());
            PlayerPrefs.SetString("third_string", MySharedData.GetName());
        }



    }

    
}
