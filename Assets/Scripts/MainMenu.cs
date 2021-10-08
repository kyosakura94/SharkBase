using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame() //Method to start game
    {
        SceneManager.LoadScene("SpawnScene"); //Select what scene you will change to
    }

    public void QuitGame() //Method to quit game
    {
        Debug.Log("QUIT");
        Application.Quit(); //Quit the game
    }
	
}
