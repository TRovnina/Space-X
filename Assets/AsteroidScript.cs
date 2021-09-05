using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject shipExplosion;

    public float minSpeed, maxSpeed;
    public float rotationSpeed;
    private Rigidbody _asteroid;

    // Start is called before the first frame update
    void Start()
    {
        // get asteroid
        _asteroid = GetComponent<Rigidbody>();
        // random speed of rotation
        _asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        //set speed
        var randomSpeed = Random.Range(minSpeed, maxSpeed);
        _asteroid.velocity = new Vector3(0, 0, -randomSpeed);
    }

    // Collision with other objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Asteroid" || ControllerScript.instance.end)
            return;

        // gameObject = current object
        Destroy(gameObject);
        Destroy(other.gameObject);

        // show Explosion
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        // show Explosion of the ship
        if (other.tag == "Player")
        {
            Instantiate(shipExplosion, other.transform.position, Quaternion.identity);
            ControllerScript.instance.end = true;
            return;
        }

        ControllerScript.instance.IncreaseScore(10);
    }
}
