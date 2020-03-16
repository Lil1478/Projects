using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QGame()
    {
        Application.Quit();
    }
}
