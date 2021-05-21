using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseScript : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject Pausemenu;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        if (GameIsPause)
        {
            Time.timeScale = 0f;
        }

    }
    public void Pause()
    {
        GameIsPause = true;
        Time.timeScale = 0f;
        Pausemenu.SetActive(true);
       
    }
    public void Resume()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;

    }
   
    public void LoadMENU()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
    public void QuitGame() //QUITS GAME
    {
        Debug.Log("QUIT");
        Application.Quit();
       
    }
}
