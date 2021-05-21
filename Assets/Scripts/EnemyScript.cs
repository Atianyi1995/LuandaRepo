using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float nextfire;
    private float fireRate = 5;
    public Animator anim;
    private float be = 2;
    public Transform spawnpoint;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nextfire = UnityEngine.Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
   
    void Shoot()
    {
        be = UnityEngine.Random.Range(10,20);
        
        if (Time.time > nextfire)
        {
            anim.SetBool("shoot", true);
            Invoke("throwing", 0.3f);
            //FindObjectOfType<AudioManager>().Play("wraithshot");
            fireRate = UnityEngine.Random.Range(2, 5);
            nextfire = Time.time + fireRate;

          
            
        }
    }
    void throwing()
    {
        FindObjectOfType<AudioManager>().Play("throwSpear");
        GameObject spawnbullet = Instantiate(bullet, spawnpoint.position, spawnpoint.rotation) as GameObject;
        Rigidbody2D rigidbody2D = spawnbullet.GetComponent<Rigidbody2D>();

        rigidbody2D.AddForce(transform.right * be, ForceMode2D.Impulse);
        Destroy(spawnbullet, 3f);
        anim.SetBool("shoot", false);
    }
    public void death()
    {
        FindObjectOfType<AudioManager>().Play("EnemyHurt");
        anim.SetBool("die", true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Invoke("dead", 2f);
    }
    void dead()
    {
        gameObject.SetActive(false);
    }
}
