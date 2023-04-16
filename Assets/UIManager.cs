using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;

    public void Home(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Options(){
        optionsPanel.SetActive(true);
    }

    public void ConfirmOptions(){
        optionsPanel.SetActive(false);
    }
}
