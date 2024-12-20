using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBulletPlayerController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else {
            Destroy(gameObject);
            if (collision.gameObject.tag != "Wall") {
                Destroy(collision.gameObject);          
            }
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
