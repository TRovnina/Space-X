using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // information where laserGun is
    public Transform laserGun;
    public GameObject laserShot;
    public float shotDelay;
    private float _nextShotTime;

    public float xMin, xMax, zMin, zMax;
    public float speed;
    public float tilt;
    private Rigidbody _player;

    // Start is called before the first frame update
    void Start()
    {
        //get our spaceship
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControllerScript.instance.isStarted)
            return;

        // if player wants to move on horizontal ax
        var moveHorizontal = Input.GetAxis("Horizontal"); // -1 ... 1
        // if player wants to move on vertical ax
        var moveVertical = Input.GetAxis("Vertical"); // -1 ... 1

        // set speed
        _player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        // restrict movement
        var clampedX = Mathf.Clamp(_player.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(_player.position.z, zMin, zMax);

        // set position
        _player.position = new Vector3(clampedX, 0, clampedZ);

        // tilt according to direction
        _player.rotation = Quaternion.Euler(_player.velocity.z * tilt, 0, -_player.velocity.x * tilt);

        // Time.time = current time. Fire1 = M1 / Ctrl
        if (Time.time > _nextShotTime && Input.GetButton("Fire1"))
        {
            // create shot. Quaternion.identity = no rotation
            Instantiate(laserShot, laserGun.position, Quaternion.identity);
            _nextShotTime = Time.time + shotDelay;
        }

    }
}
