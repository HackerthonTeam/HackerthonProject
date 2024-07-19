using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool isPanelActive = false;
    public GameObject panel;
    public Slider slider;
    public void Quit(){
        Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene("");
    }
    public void PanelQuit(){
        panel.SetActive(false);
        isPanelActive=false;
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
    void Start(){
        Debug.Log(1);
        //SoundManager.Instance.BackgroundPlay("1",100);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPanelActive){
                panel.SetActive(false);
                isPanelActive = false;
            }
            else{
                panel.SetActive(true);
                isPanelActive = true;
            }
        }
    }
}
