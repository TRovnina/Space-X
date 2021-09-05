using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{

    public float speed;
    private Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // loop motion background
        var offset = Mathf.Repeat(Time.time * speed, 150);
        // Vector3.back - vector to down
        transform.position = _startPosition + Vector3.back * offset;
    }
}
