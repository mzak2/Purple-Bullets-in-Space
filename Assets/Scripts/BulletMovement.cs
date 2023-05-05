using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //partitioned to avoid updating
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    
        if(transform.position.x > 15) 
        {
            Destroy(gameObject);        
        }

    }

}
