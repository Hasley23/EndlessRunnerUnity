using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    public void StartGame() {
        SceneManager.UnloadSceneAsync("lobby");
        SceneManager.LoadScene("game");

        
    }
    public void Quit() {
        Debug.Log("I will wait for you...");
        Application.Quit();
    }

    public void MaimMenu() {
        SceneManager.UnloadSceneAsync("game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        
    }
}
