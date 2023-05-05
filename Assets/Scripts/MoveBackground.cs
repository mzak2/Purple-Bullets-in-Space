using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private float speed = 25;
    private GameManager gameManager;
    private Vector3 startPos;
    private float repeatWidth = 500;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //finds game manager
        startPos = transform.position; //get initial position of background
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive == true) //only moves background when game is playing
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); //moves the background faster or slower to the left
        }

        if(transform.position.x < -repeatWidth) //tells when to repeat the background
        {
            transform.position = startPos; // send background back to original position to repeat
        }
        
    }
}
