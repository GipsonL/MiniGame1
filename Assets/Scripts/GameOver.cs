using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        DataSaver.Save();
        Debug.Log(PlayerPrefs.GetInt("first_int"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
