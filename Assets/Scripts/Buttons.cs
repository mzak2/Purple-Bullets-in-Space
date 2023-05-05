using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty = 1; //assigns difficulty to the button in inspector and be changed to speed up/ slow down spawns

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //finds the game manager
        button = GetComponent<Button>(); //gets the buttons assigned 
        button.onClick.AddListener(SetDifficulty); //tells the game to "listen" for button press for normal or ludicrous
    }

    // Update is called once per frame
    void SetDifficulty() //sets dififcult based on normal/ludicrous
    {
        Debug.Log(button.gameObject.name + " was clicked"); //tells us the button functioned
        gameManager.StartGame(difficulty); //starts game based on difficulty
    }
}
