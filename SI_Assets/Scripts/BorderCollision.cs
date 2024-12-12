using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    //Event that takes the collision 2D objetct
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Wall collision");
        //Destroys the gameObject that collides with teh walls/ the OG that holds the script
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }    
    }


    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
