using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    private GameManager gameManager;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //assigns enemy health to be equal at beginning of game
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find game manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount) //method for when an enemy is damaged and lowers it is called for collisions in Detect collision script line 39
    {
        currentHealth -= amount; //minus health equal to "amount" on player bullet
        if(currentHealth <= 0) //if enemy hits 0 health
        {
            Destroy(gameObject); //destroy enemy
            gameManager.UpdateScore(pointValue); //update score
        }
    }

}
