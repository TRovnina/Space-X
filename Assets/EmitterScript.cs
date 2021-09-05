using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{

    public GameObject asteroid;
    public float minDelay, maxDelay;

    private float _nextLaunchTime;

    // Update is called once per frame
    void Update()
    {
        if (!ControllerScript.instance.isStarted)
            return;

        // emit asteroid
        if (Time.time > _nextLaunchTime)
        {
            var positionZ = transform.position.z;
            var positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            var newPosition = new Vector3(positionX, 0, positionZ);

            Instantiate(asteroid, newPosition, Quaternion.identity);

            _nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
