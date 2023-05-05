using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5;
    public GameObject projectilePrefab;
    private float fireInterval = 2;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRoutine()); // begins enemy fire routine when they spawn
    }

    // Update is called once per frame
    void Update()
    {

        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // move enemy left at given speed
        }

        if (transform.position.x < -25) // if enemy moves past player camera bounds, destroy object
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -7) // if enemy moves below player camera bounds destroy object
        {
            Destroy(gameObject);
        }
    }

    IEnumerator FireRoutine() //method for enemy to fire
    {
        while (true)
        {
            offset = new Vector3(-2, 0, 0); //places the bullet in front of the enemy so it doesnt kill them and looks like it shoots from front
            yield return new WaitForSeconds(fireInterval); //keeps enemies from firing constantly and fires on intervals
            Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity); //creates the enemy bullet
        }
    }
}
