using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    LuandaScript luanda;
    public GameObject dust;
    // Start is called before the first frame update
    void Start()
    {
        luanda = FindObjectOfType<LuandaScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            luanda = collision.GetComponent<LuandaScript>();
            luanda.TakeDamage(20);
            gameObject.SetActive(false);
            //XpLODE();
            GameObject spawnbullet = Instantiate(dust, transform.position, Quaternion.identity) as GameObject;
        }

        if (collision.gameObject.tag == "Rocks")
        {
            //enemy = collision.GetComponent<EnemyScript>();
            //enemy.TakeDamage(20);
            gameObject.SetActive(false);
            //XpLODE();
             GameObject spawnbullet = Instantiate(dust, transform.position, Quaternion.identity) as GameObject;
        }
    }
    
}
