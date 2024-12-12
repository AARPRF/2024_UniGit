using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    //speed always float
    public float speed = 10.0f;
    private Rigidbody2D rigidbody= new Rigidbody2D();
    private Animator myAnim = new Animator();

    // Start is called before the first frame update
    void Start()
    {   
        //Initialize at start component
        rigidbody = GetComponent<Rigidbody2D>();   
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        //1. Move
        //Here we get wether A or D, left or right has pressed
        float h = Input.GetAxis("Horizontal");
        //Here we get wether W or S, up or down has pressed
        float v = Input.GetAxis("Vertical");

        //Object to hold x,y dupla
        Vector2 dir = new Vector2(h, v);

        //Apply to rigidbody that contains this component, diagonal speed, normalized (do not increase)
        rigidbody.velocity = dir.normalized * speed;

        //2.Animator states.
        //GetComponent<Animator>().SetBool("isFlyingLeft",h < 0);
        myAnim.SetBool("isFlyingLeft", h < 0);
        myAnim.SetBool("isFlyingUp", v > 0);
        myAnim.SetBool("isFlyingRight", h > 0);
        


    }
}
