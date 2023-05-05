using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    public GameObject levelOne;
    public GameObject levelTwo;
    public GameObject levelThree;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    private float yTop = 7;
    private float yBottom = -10;
    private float xLeft = 12;
    private float xRight = 14;
    //private float startDelay = 3;
    //private float repeatRate = 2;
    public int lives;
    private int score;
    private float spawnRate = 2.0f;
    public PlayerController player;

    // Start is called before the first frame update
    public void StartGame(int difficulty) //sets criteria for starting the game after pressing normal/ludicrous
    {
        isGameActive = true; // bool to determine the state of the game used in many methods throughout
        score = 0; //gives player score of 0 at start
        lives = 3; // gives player 3 lives at start
        levelText.text = "Level: 1"; //tells the player that they are on level 1
        spawnRate = spawnRate / difficulty; // determines spawn speed for ludicrous and normal

        StartCoroutine(SpawnEnemy()); //spawns enemies
        UpdateScore(0); //begins update score method with no change in value
        UpdateLives(0); //begins update lives method with no change in value
        titleScreen.SetActive(false); // hides the title screen on play
        player.ParticleStart(); //plays player dirt particles
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemy() //method for spawning enemy called on line 41
    {
        while(isGameActive) 
        {
            yield return new WaitForSeconds(spawnRate); //waits x seconds to begin spawning enemies
            //InvokeRepeating("SpawnRandomEnemy", startDelay, repeatRate);
            int index = Random.Range(0, enemyPrefabs.Count); //indexes enemy prefabs randomly

            if (isGameActive)
            {
                Instantiate(enemyPrefabs[index], RandomSpawnPosition(), enemyPrefabs[index].transform.rotation); //spawns enemy prefabs randomly using above index
            }
        }
    }

    public void UpdateScore(int scoreToAdd) // method for updates to player score
    {
        score += scoreToAdd; //adds score
        scoreText.text = "Score: " + score; //assigns in the text to display score properly
        if (score >= 100) //changes to level 2 based on score >100
        {
            levelOne.gameObject.SetActive(false); //sets level 1 background to false
            levelTwo.gameObject.SetActive(true); // sets level 2 background to true
            levelText.text = "Level: 2"; //displays text to indicate to player what level they're on
        }

        if (score >= 200) //changes to level 2, using similiarites from level 1 change
        {
            levelOne.gameObject.SetActive(false);
            levelTwo.gameObject.SetActive(false);
            levelThree.gameObject.SetActive(true);
            levelText.text = "Level: 3";
        }
    }

    public void UpdateLives(int livesToRemove) //updates player lives
    {
        if(isGameActive)
        {
            lives -= livesToRemove; //removes a life
            livesText.text = "Lives: " + lives; //displays number of lives
            if(lives <= 0) //kills player at 0 lives
            {
                GameOver();
            }
        }
    }

    public void GameOver() //the game over state
    {
       restartButton.gameObject.SetActive(true); //turns on restart button
       gameOverText.gameObject.SetActive(true); //shows the mission end text
       isGameActive = false; 
       player.ExplosionStart(); //plays explosion animation and sound on player death
    }

    Vector3 RandomSpawnPosition() //spawns enemies randomly within an area
    {
            Vector3 spawnPosition = new Vector3(Random.Range(xLeft, xRight), Random.Range(yBottom, yTop), -2); // gives parameters for left right and top down for spawning enemies
            Debug.Log("Spawned"); //checks to make sure enemies are spawning
            return spawnPosition; //actually spawns enemy
    }
    public void RestartGame() //resets scene to original state to begin again
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //resets to original  scene
    }
}
