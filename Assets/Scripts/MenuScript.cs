using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    private void Start()
    {
       // FindObjectOfType<AudioManager>().Play("menu");
        Time.timeScale = 1;
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");

    }
    public void QuitGame() //QUITS GAME
    {
        Debug.Log("QUIT");
        Application.Quit();

    }
}
