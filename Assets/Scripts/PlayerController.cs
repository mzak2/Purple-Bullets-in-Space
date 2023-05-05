using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10;
    public float yTop = 7;
    public float yBottom = -10;
    public float xLeft = -22;
    public float xRight = 11;
    public GameObject projectilePrefab;
    private GameManager gameManager;
    private AudioSource playerAudio;
    public AudioClip playerBulletSound;
    public AudioClip playerExplosionSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find game manager to get script
        playerAudio = GetComponent<AudioSource>(); // get audio source from player gameobject
     
    }

    public void ParticleStart() //play the dirt particles after the player presses normal/ludircrous and is call in game manager line 45 for gamestart
    {
        dirtParticle.Play(); //plays dirt particle
        GetComponentInChildren<SpriteRenderer>().enabled = true; // renders player on to work with explosion on gameover
    }

    public void ExplosionStart() //players explosion when players lives hit 0 and gameover
    {
        explosionParticle.Play(); //plays explosion particle
        GetComponentInChildren<SpriteRenderer>().enabled = false; //hides the player sprite after explosion
        dirtParticle.Stop(); //no longer plays the movement particles
        playerAudio.PlayOneShot(playerExplosionSound, 0.8f); //plays explosion sound
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.isGameActive == true) //allows player to control ship after normal/ludicrous is pressed
        {
            
            // keep player within bounds for X and Y values
            if (transform.position.y > yTop)
            {
                transform.position = new Vector3(transform.position.x, yTop, transform.position.z);
            }

            if (transform.position.y < yBottom)
            {
                transform.position = new Vector3(transform.position.x, yBottom, transform.position.z);
            }

            if (transform.position.x < xLeft)
            {
                transform.position = new Vector3(xLeft, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRight)
            {
                transform.position = new Vector3(xRight, transform.position.y, transform.position.z);
            }

            //player input controls for A/D to go left/right and W/S to go up/down
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

            if (Input.GetKeyDown(KeyCode.Mouse0)) //fires the bullet prefab and plays the shootingf sound
            {
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
                playerAudio.PlayOneShot(playerBulletSound, 0.2f);
            }
        }
        
    }

}
