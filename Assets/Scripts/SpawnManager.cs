using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private bool _spawnEnnemi = false;

    public void ProjectileLauch()
    {
        // _fireAction = true; // fire action triggered.
        // Debug.Log("_fireAction returned value is => " + _fireAction);
        // Chaque appui sur la touche param�tr�e dans le Input System (ici "Espace") provoque un tir de pizza.
        // Instantiate(PlayerController.projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        // _fireAction = false; // Arr�te le spawn des ennemis.

    }

    public void SpawnEnnemi()
    {
        _spawnEnnemi = true; // "S" keyboard key triggered.
        Debug.Log("_spawnEnnemi returned value is => " + _spawnEnnemi);
    }


    // Update is called once per frame
    void Update()
    {
        if (_spawnEnnemi == true)
        {
            // Fait appara�tre les ennemis (animaux) OK !
            Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);
            _spawnEnnemi = false; // Arr�te le spawn des ennemis.

        }
    }
}
