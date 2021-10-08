using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

    public GameObject panel;
    public GameObject parentPanel;

    public void PlayAgain() //Method to start game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Select what scene you will change to
    }
    public void QuitGame() //Method to quit game
    {
        Debug.Log("QUIT");
        Application.Quit(); //Quit the game
    }
    public void Instruction() //Method to quit game
    {
        parentPanel.SetActive(false);
        Debug.Log("Intruction");
        panel.SetActive(true);
    }
}
