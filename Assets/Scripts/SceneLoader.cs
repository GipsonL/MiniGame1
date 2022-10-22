using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Text remindText;
    public void LoadScene(string scene_name)
    {
        //We want users to input a name before we move on
        if (!(MySharedData.GetName().Equals("Test")) && MySharedData.GetName() != "")
            SceneManager.LoadScene(scene_name);
        else
        {
            remindText.color = Color.green;
            Invoke(nameof(changeTextBack), 1);
        }

    }
    public void changeTextBack()
    {
        remindText.color = Color.black;
    }
    public void QuitGame()
    {
        //Application.Quit() is essentially dead code here because I assume this will never actually
        //  be made into a build, but I included it anyway.
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
    public void pause()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

}
