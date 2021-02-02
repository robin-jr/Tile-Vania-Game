using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadGame()
    {
        if (FindObjectOfType<GameSession>())
        {
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
        SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        if (FindObjectOfType<GameSession>())
        {
            Destroy(FindObjectOfType<GameSession>().gameObject);
        }
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
