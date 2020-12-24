using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public void ReloadGame(){
        SceneManager.LoadScene(1);
        Time.timeScale=1;
    }

    public void QuitGame(){
        Application.Quit();
        Time.timeScale=1;

    }
}
