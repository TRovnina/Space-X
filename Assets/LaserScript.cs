using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float speed;
    private Rigidbody _laser;

    // Start is called before the first frame update
    void Start()
    {
        //get our laser
        _laser = GetComponent<Rigidbody>();
        
        //set speed
        _laser.velocity = new Vector3(0, 0, speed);
    }
}
