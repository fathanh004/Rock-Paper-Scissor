using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject toggleMute;

    public void PlayGame()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Options(){
        optionsPanel.SetActive(true);
    }

    public void ConfirmOptions(){
        optionsPanel.SetActive(false);
    }

    public void Mute(){
        if (toggleMute.GetComponent<UnityEngine.UI.Toggle>().isOn){
            AudioListener.volume = 0;
        } else {
            AudioListener.volume = 1;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
