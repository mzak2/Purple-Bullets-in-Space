using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find game manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Destroy Objects when they Collide
    private void OnTriggerEnter(Collider other)
    {
     if (gameObject.tag == "Player" && other.gameObject.tag != "Powerup") //if not player or powerup, player loses a life
        {
           gameManager.UpdateLives(1); //minus 1 player life when colliding
           Destroy(other.gameObject); //destroy enemy prefab or asteroid when colliding
        }

        if (gameObject.tag == "Player" && other.gameObject.tag == "Powerup")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag != "Enemy Bullet" && gameObject.tag != "Enemy Bullet" && other.gameObject.tag != "Player" && gameObject.tag != "Player") // only cause an enemy prefab to take 1 health dmage
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1); // minus 1 health from enemy
            Destroy(gameObject); // destroy object and bullet and update score based on assigned point values
        }
    }
}
