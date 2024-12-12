using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayerWithEnemyController : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster") {
            //Destroy player (as holds the script)
            Destroy(gameObject);
            //Destroy enemy as is the one the player collides with
            Destroy(collision.gameObject);
        }
    }

    //Event when the player destroyed
     private void OnDisable()
    {   
            //Load scene 0 - index of the scene
            SceneManager.LoadSceneAsync(0);
         
    }


    /* // Start is called before the first frame update
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {

     }*/
}
