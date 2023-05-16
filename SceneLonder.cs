using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLonder : MonoBehaviour
{
    int SceneNumber;
    void Start()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    public void selectScene()
    {
        SceneManager.LoadScene(1);
    }
    public void gameScene()
    {
        SceneManager.LoadScene(3);
    }
    public void settingScene()
    {
        SceneManager.LoadScene(2);
    }
    public void loadStratScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
