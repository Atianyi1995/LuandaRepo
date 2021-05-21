using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
   
   
    public Rigidbody2D rb2D;
    GameManagerScript manager;
    public EnemyScript enemy;
    public GameObject dust;
    // Start is called before the first frame update
    private void Awake()
    {
       
        rb2D = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 camerTarget = transform.position;

        if (!manager.CheckIfWithinScreenLimits(camerTarget))
        {
            Vector3 offsetFromCamPosition = Vector3.zero;
            offsetFromCamPosition = camerTarget - Camera.main.transform.position;
            Destroy();

        }
        if (transform.position.y < 1.5)
        {
            rb2D.drag = 0.5f;
        }
        
        else if (transform.position.y > 1.5)
        {
            rb2D.drag = 1f;
        }
        if (transform.position.y > 3.2)
        {
            rb2D.drag = 1.5f;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.GetComponent<EnemyScript>();
            enemy.death();
            gameObject.SetActive(false);

            GameObject spawnbullet = Instantiate(dust, transform.position, Quaternion.identity) as GameObject;
            
            
        }
        if (collision.gameObject.tag == "Spear")
        {
            //enemy = collision.GetComponent<EnemyScript>();
            //enemy.TakeDamage(20);
            gameObject.SetActive(false);
            GameObject spawnbullet = Instantiate(dust, transform.position, Quaternion.identity) as GameObject;
        }


    }
    void Destroy()
    {
        gameObject.SetActive(false);
    }
    
   
}
