using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    //Linkin with a sliceFruit object
    public GameObject slicedFruitPrebab;
    public float explosionRadius = 5f;

    //After creating GameManager
    //GameManager 1.Increase Score
    private GameManager myGM;
    public int scoreAmount = 3;


    public void CreateSlicedFruit() {
        GameObject inst = Instantiate(slicedFruitPrebab, transform.position, transform.rotation);

        //Has to take the children rigidbodys of the banana cut
        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        //Iterate through all the rigidbodys inside
        foreach (Rigidbody rb in rbOnSliced) {
            //Adds the force in unprecitable direction and differen force ranges
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500,1000), transform.position, explosionRadius);
        }

        //GameManager 1.Increase Score
        //After creating and call in Start method the general Manager. Place the value we want for example 3.
        myGM.IncreaseScore(scoreAmount);

        //GameManager 7.Play sound
        //Trigger sound
        myGM.PlayRandmoSliceSound();

        //Destroy current slice fruit after some time, else we have a problem
        Destroy(inst, 5f);

        //Destroy current fruit(banana uncut)
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameManager 1.Increase Score
        myGM = FindObjectOfType<GameManager>();
    }

    // 1.Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateSlicedFruit();
        }
    }

    //2.Blade destroyer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BladeController b = collision.GetComponent<BladeController>();
        if (!b)
        {
            return;
        }

        CreateSlicedFruit();
    }
}
