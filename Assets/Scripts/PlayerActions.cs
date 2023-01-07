using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public void SpawnPlayer(bool _reSpawn)
    {
        transform.position = Vector2.zero;
        Debug.Log("Respawn player requested");
    }
}
