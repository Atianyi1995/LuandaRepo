using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
 
    public static ObstaclePooler Instance;
    public int amountToPool;
    public List<GameObject> Rock;
    public GameObject RockPrefab;
    public List<GameObject> Spear;
    public GameObject SpearPrefab;
    //public List<GameObject> Mace;
    //public GameObject MacePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Rock = new List<GameObject>();
        Spear = new List<GameObject>();
        //Mace = new List<GameObject>();

       
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obstacle = Instantiate(RockPrefab) as GameObject;
            obstacle.SetActive(false);
            Rock.Add(obstacle);
        }
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obstacle = Instantiate(SpearPrefab) as GameObject;
            obstacle.SetActive(false);
            Spear.Add(obstacle);
        }
        //for (int i = 0; i < amountToPool; i++)
        //{
        //    GameObject obstacle = Instantiate(MacePrefab) as GameObject;
        //    obstacle.SetActive(false);
        //    Mace.Add(obstacle);
        //}

    }

    //public GameObject GetPooledObject()
    //{
    //    for (int i = 0; i < Rock.Count; i++)
    //    {
    //        if (!Mace[i].activeInHierarchy)
    //        {

    //            return Mace[i];
    //        }


    //    }
    //    return null;
    //}
    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < Rock.Count; i++)
        {
            if (!Rock[i].activeInHierarchy)
            {
                
                return Rock[i];
            }
           

        }
        return null;
    }
    public GameObject GetPooledObject3()
    {
        for (int i = 0; i < Spear.Count; i++)
        {
            if (!Spear[i].activeInHierarchy)
            {
                
                return Spear[i];
            }

        }
        return null;
    }
    // Update is called once per frame

}
