using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We want to pause the game when meet the blade
        BladeController b= collision.GetComponent<BladeController>();
        if (!b) {
            return;
        }

        FindObjectOfType<GameManager>().OnBombHit();
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
