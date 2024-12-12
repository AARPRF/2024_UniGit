using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerController : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {   //In start because we want the calculation when generate the bullet

        //Game object that "follows" the element with that tag
        GameObject gameObject = GameObject.FindWithTag("Player");
        //transform.position position of the gameobject that holds the script
        //gameObject.transform.position will gameobject that is our player

        //position of the player - position of this object. This will give the direction.
        //Vector3 v3 = (gameObject.transform.position - transform.position).normalized;
        //Vector2 v2= new Vector2 (v3.x, v3.y);
        //GetComponent<Rigidbody2D>().velocity = v2*speed;

        if (gameObject != null) {
            Vector2 playerPos = (gameObject.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = playerPos * speed;
        }
        
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
}
