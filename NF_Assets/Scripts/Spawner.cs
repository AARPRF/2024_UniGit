using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    //2.**At the beginning of the spawner, just bananas 
    //public GameObject fruitToSpawnPrefab;
    
    public Transform[] spawnPlaces;
    public float minWait = 0.3f;
    public float maxWait = 1f;

    //2.1.
    public float minForce = 10f;
    public float maxForce = 20f;
    //3. multiple fruits and bombs
    //Later array de GameoBjetcs
    public GameObject[] fruitToSpawnPrefabs;
    //3.
    //New GO for Bomb, otherwise we do not have control in spawning
    public GameObject BombPrefab;
    //Odds to throw bomb
    public int chanceToSpawnBomb = 10;

    // Start is called before the first frame update
    void Start()
    {
        //2.
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    //2. La creación de la subrutina
    private IEnumerator SpawnFruits() {
        //2.Loop infinito
        while(true)
        {
            //2.Random entre 2 valores
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            //Log for make sure that enters in the coroutine with Console
            Debug.Log("Spawning fruit");

            //2.1. Crear spawners y luego vincularlos a este script
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            //2.** Related with spawning just bananas
            //GameObject fruit = Instantiate(fruitToSpawnPrefab.gameObject, t.position, t.rotation);
    

            //3.Random fruit/bomb generator
            //generic go to instantiate
            GameObject go = null;
            float rnd =Random.Range(0, 100);
            if (rnd < chanceToSpawnBomb)
            {
                go = BombPrefab;
            }
            else {
                go = fruitToSpawnPrefabs[Random.Range(0,fruitToSpawnPrefabs.Length)];
            }
            GameObject fruit = Instantiate(go, t.position, t.rotation);
            //
            

            //2.1. Lanzar las frutas
            //A lot created here, t position random, random force between selectable force, forceMode impulse
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up*Random.Range(minForce,maxForce), ForceMode2D.Impulse);
            Destroy(fruit, 5f);
        }
    }
        

}
