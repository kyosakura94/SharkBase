using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgian : MonoBehaviour
{

    public void PlayAgain() //Method to start game
    {
        SceneManager.LoadScene("Main Menu"); //Select what scene you will change to
    }
}