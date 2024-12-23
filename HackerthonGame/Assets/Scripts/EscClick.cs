using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscClick : MonoBehaviour
{
    public Image pauseWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseWindow.gameObject.activeSelf) DisablePause();
            else EnablePause();
        }
    }

    void EnablePause()
    {
        pauseWindow.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void DisablePause()
    {
        pauseWindow.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnResumeClick()
    {
        DisablePause();
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
