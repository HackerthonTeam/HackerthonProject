using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void MainMenuLoad()
    {
        SceneManager.LoadScene("Start_Scene");
    }
    public void StartSceneMove()
    {
        SceneManager.LoadScene("Load_Scene");
    }
    public void TutorialSceneload()
    {
        SceneManager.LoadScene("Tutorial_Scene");
    }
    public void SettingSceneLoad()
    {
        SceneManager.LoadScene("Setting_Scene");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
