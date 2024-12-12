using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonstersController : MonoBehaviour
{
    public GameObject monster1;
    public GameObject monster2;
    public float interval = 3f;
    public float startInterval = 1f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMonster", startInterval, interval);
    }

    private void SpawnMonster()
    {
        float myRandom = Random.value;

        if (myRandom < 0.2) {
            GameObject g = Instantiate(monster1, transform.position, Quaternion.identity);
        }
        else if(myRandom < 0.4)
        {
            GameObject g = Instantiate(monster2, transform.position, Quaternion.identity);
        }
        else
        {
            //Do not spawn monster
        }
    }

    // Update is called once per frame
   /* void Update()
    {
        
    }*/
}
