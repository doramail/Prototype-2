using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Destroys the ennemi
        Destroy(other.gameObject); // Destroys the player
    }
}
