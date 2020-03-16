using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_screen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_001");
        StaticClass.CrossSceneInformation = 1;
    }
    public void PlayGame2()
    {
        SceneManager.LoadScene("Scene_001");
        StaticClass.CrossSceneInformation = 2;
    }
    public void PlayGame3()
    {
        SceneManager.LoadScene("Scene_001");
        StaticClass.CrossSceneInformation = 3;
    }


}
