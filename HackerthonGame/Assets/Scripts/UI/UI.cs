using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool isPanelActive = false;
    bool isInfoPanelActive = false;
    public GameObject panel;
    public GameObject InfoPanel;
    public Slider slider;
    public void Quit(){
        Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene("Load_Scene");
    }
    public void PanelQuit(){
        panel.SetActive(false);
        isPanelActive=false;
    }
    public void InfoPanelQuit(){
        InfoPanel.SetActive(false);
        isInfoPanelActive=false;
    }
    public void PanelActive(){
        if(isPanelActive){
            panel.SetActive(false);
            isPanelActive = false;
        }
        else{
            panel.SetActive(true);
            isPanelActive = true;
        }
    }
    public void InfoPanelActive(){
        if(isInfoPanelActive){
            InfoPanel.SetActive(false);
            isInfoPanelActive = false;
        }
        else{
            InfoPanel.SetActive(true);
            isInfoPanelActive = true;
        }
    }
    void Start(){
        Debug.Log(1);
        //SoundManager.Instance.BackgroundPlay("1",100);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isInfoPanelActive){
                if(isPanelActive){
                panel.SetActive(false);
                isPanelActive = false;
                }
                else{
                panel.SetActive(true);
                isPanelActive = true;
                }
            }
            if(isInfoPanelActive){
                InfoPanel.SetActive(false);
                isInfoPanelActive = false;
            }
        }
    }
}
