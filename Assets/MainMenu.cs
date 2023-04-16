using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;

    public void Singleplayer()
    {
        SceneManager.LoadScene("Battle");
        BattleManager.SetMultiplayer(false);
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Battle");
        BattleManager.SetMultiplayer(true);
    }

    public void Options(){
        optionsPanel.SetActive(true);
    }

    public void ConfirmOptions(){
        optionsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
