using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManagerScript : MonoBehaviour
{
   
    public GameObject GameOver;
    public GameObject Complete;
    public ObstaclePooler pooler;
    public static GameManagerScript instance;
    int sceneIndex;
    public GameObject Finger;
    public GameObject Pull;

    // Start is called before the first frame update

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
      if (sceneIndex == 1)
      {
            Invoke("StopTot", 5f); 
      }
     
    }
    void StopTot()
    {
        Finger.SetActive(false);
        Pull.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindWithTag("Enemy"))
        {
            GameComplete();
        }
       
    }
    public void Objectif()
    {
        GameOver.SetActive(true);
         Invoke("SceneM", 2f);
    }
    void SceneM()
    {
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    public void GameComplete()
    {
        Complete.gameObject.SetActive(true);
        if(sceneIndex < 3)
        {
            Invoke("NextLevel", 2f);
        }
        if(sceneIndex == 3)
        {
            Invoke("SceneM", 2f);
        }
        
    } 

    public bool CheckIfWithinScreenLimits(Vector2 point)
    {

        //we test if point.y is greater than the rightmost edge of the screen
        if (point.y > Camera.main.transform.position.y + Camera.main.orthographicSize)
        {
            return false;
        }
        if (point.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            return false;
        }

        if (point.x > Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect)
        {
            return false;
        }


        if (point.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect)
        {
            return false;
        }

        return true;
    }

}
