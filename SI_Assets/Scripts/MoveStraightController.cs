using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraightController : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //This way rigidbody is taken from the rigidbody of the gameObject that has this script
        rigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = velocity;
    }
}
