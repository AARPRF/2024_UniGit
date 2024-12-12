using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletController : MonoBehaviour
{
    public GameObject bullet;
    public float interval = 1f;
    public float startInterval =1f;
    // Start is called before the first frame update
    void Start()
    {
        //ShootBullet();
        InvokeRepeating("ShootBullet", startInterval, interval);
 
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

    //New methods
    private void ShootBullet() {
        //Created in the position of the player, with no rotation
        GameObject g = Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
