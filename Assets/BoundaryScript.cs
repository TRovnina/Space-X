using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    // Leaving the object of the play area
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}