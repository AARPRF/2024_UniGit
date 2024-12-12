using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    //1.
    private Rigidbody2D rb;


    //2.
    //Prepar game to mobile. Just activate collider when mouse moves
    //Move a certain lenght in the 3D world
    public float minVelo = 0.1f;
    //By default this will be 0,0,0
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;
    private Collider2D collider;

    //1. Earlier than the Start method
    // Si otro elemento depende de otro, se utilizará el awake
    private void Awake()
    {
        //1.
        rb = GetComponent<Rigidbody2D>();

        //2.
        //Prepare game to mobile
        collider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    {
        //1.Method that we create
        SetBladeToMouse();

        //2. Enable collider when mouse moving. Collider.enabled is a boolean
        collider.enabled = IsMouseMoving();
    }

    //1. Conseguir la posición del ratón.
    //(No hace nada pero aparecera en la pantalla con el trail)
    private void SetBladeToMouse() {
        var mousePos = Input.mousePosition;
        //The spawner is at z=0
        //The camera is at z=-10 and is the reference that we are going to take
        mousePos.z = 10;

        //This change the mouse position to a point into the scene world 
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);

        //1.1 - El siguiente paso poner en Collider IsTrigger y volver al Fruit
        //para detonar los cortes con OnTriggerEnter2D
    }


    //2.
    //Helper method to define when mouse is moving return true
    private bool IsMouseMoving() {
        //Get current position
        Vector3 curMousePos = transform.position;
        //Calculate how much the mouse has changed since
        //last time this method was called
        //Magnitude return the lenght of the vector
        float traveled = (lastMousePos - curMousePos).magnitude;
        
        //Update last mouse with current to do the calculation in the next
        lastMousePos = curMousePos;

        if (traveled > minVelo)
        {
            return true;
        }
        else {
            return false;
        }
    } 

}
