using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{

    private Vector3 targetPlayer;
    private Vector3 direction;
    private GameObject player;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); //finds player
        if (player != null) // makes sure player is active
        {
            targetPlayer = player.transform.position; //gets vectors to shoot bullet where the player is
        }
        else
        {
            Debug.LogError("Player is null"); // tells us if the player isnt recognized
        }

        Destroy(gameObject, 10f); //destroys the bullet if touches the player
        direction = (targetPlayer - transform.position).normalized * speed; // moves bullets towards player
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime); //speed at which bullet moves
    }
}
