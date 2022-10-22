using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTransistor : MonoBehaviour
{
    public GameObject text;
    public GameObject data;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MySharedData.SetName(text.GetComponent<InputField>().text);
        }
        Debug.Log(MySharedData.GetName());
    }
    
}
