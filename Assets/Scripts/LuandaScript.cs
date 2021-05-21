using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuandaScript : MonoBehaviour
{
    private Vector3 startDragPosition; 
    public Vector3 endDragPosition;
    public Vector3 stopDrag;
    public bool BallRelease;
    public bool release;
    public bool didDrag;
    public bool didClick;
    public bool hrow;
    public RockScript rock;
    public Transform spawnpoint;
    private ParticleSystem ps;
    public GameObject ParticleSystemPrefab;
    GameManagerScript manager;
    [SerializeField]
    private float speed = 1;
    private Animator anim;
    public SpriteRenderer sprite;
    public Sprite newsprite;
    float rotating;
    //bool rotated;
    //private float nextFire;
    //private float fireRate = 0.5f;
    public GameObject bone;
    int maxHeath = 40;
    public int currentHealth;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
       // bone = GetComponent<Transform>().Find("bone_3");
        manager = FindObjectOfType<GameManagerScript>();
        anim = GetComponent<Animator>();
        stopDrag = new Vector3(-1.5f, -1.5f, 0);
        rotating = 118.326f;
        currentHealth = maxHeath;
    }
    void ChangeSprite()
    {
        sprite.sprite = newsprite;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.back * -10;
        release = false;

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("aim", true);
            didClick = true;
            startDragPosition = worldPosition;
            ChangeSprite();
        }
        else if (Input.GetMouseButton(0))
        {
            didDrag = true;
            //arrow.SetActive(true);
           // ControlPlayer();
        }
        else if (Input.GetMouseButtonUp(0))
        {

            endDragPosition = worldPosition - startDragPosition;
            if (endDragPosition.x < stopDrag.x)
            {
                
                endDragPosition.x = stopDrag.x;
            }
            if (endDragPosition.y < stopDrag.y)
            {
                
                endDragPosition.y = stopDrag.y;
            }
            if (endDragPosition.x < -1)
            {
                hrow = true;
                anim.SetBool("throw", true);
                Invoke("Throw", 0.3f);
            }
            else
            {
                anim.SetBool("aim", false);
            }
            if (!hrow)
            {
                anim.SetBool("aim", false);
            }
            didDrag = false;
            didClick = false;
            release = true;

        }
        if (didDrag)
        {
            endDragPosition = worldPosition - startDragPosition;

        }
        if (!didDrag)
        {
            if (endDragPosition.x > 0 || endDragPosition.y > -3)
            {
                release = true;
            }
        }
       
    }
    void LateUpdate()
    {
       
        
        if (Input.GetMouseButton(0))
        {
           rotating = (endDragPosition.y + endDragPosition.z)/2;
            if (bone != null)
            {
                if (endDragPosition.x < -1)
                {
                    bone.transform.Rotate(0, 0, -rotating);
                }
                   
                
            }
            else
            {
                Debug.Log("bone is null!");
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
          

            if (bone != null)
            {
                bone.transform.eulerAngles = new Vector3(0, 0, 118.326f);
               
            }
            else
            {
                Debug.Log("bone is null!");
            }
        }
    }
      
    public void Throw()
    {
        Invoke("CanCel", 0.3f);
        StartCoroutine(LaunchBall());
    }
    public IEnumerator LaunchBall()
    {
       
        
          
            if (endDragPosition.x < -1)
            {
            FindObjectOfType<AudioManager>().Play("luandaSpeak");
            FindObjectOfType<AudioManager>().Play("throwRock");
            
            GameObject pooledPickup = ObstaclePooler.Instance.GetPooledObject2();
            pooledPickup.transform.position = spawnpoint.position;
            pooledPickup.transform.rotation = spawnpoint.rotation;
            pooledPickup.SetActive(true);

            //pooledPickup = Instantiate(kunai, spawnpoint.position, spawnpoint.rotation) as GameObject;
            Rigidbody2D rigidbody2D = pooledPickup.GetComponent<Rigidbody2D>();

            rigidbody2D.AddForce(-endDragPosition * speed, ForceMode2D.Impulse);

            Vector3 camerTarget = pooledPickup.transform.position;
            if (!manager.CheckIfWithinScreenLimits(camerTarget))
            {
                Vector3 offsetFromCamPosition = Vector3.zero;
                offsetFromCamPosition = camerTarget - Camera.main.transform.position;
                pooledPickup.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
            }

        
        endDragPosition = new Vector3(0f, 0f, 0);
    }
    void CanCel()
    {
        anim.SetBool("throw", false);
        anim.SetBool("aim", false);
        hrow = false;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetBool("hurt", true);
        Invoke("NoHurt", 0.5f);

          
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyHurt");
            manager.Objectif();
            currentHealth = 0;
            dead = true;
            anim.SetTrigger("die");
            
            GetComponent<Collider2D>().enabled = false;

            this.enabled = false;
            Invoke("DeathSound", 0.5f);
            Invoke("Die", 1f);
        }
        else
        {
            dead = false;
        }
        
    }
    void NoHurt()
    {
        anim.SetBool("hurt", false);
    }
    void Die()
    {
        gameObject.SetActive(false);
    }

}
