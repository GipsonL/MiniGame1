using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherSceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string scene_name)
    {
 
            SceneManager.LoadScene(scene_name);

    }
}
