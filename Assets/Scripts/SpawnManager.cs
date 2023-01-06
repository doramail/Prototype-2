using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private bool _spawnEnnemi = false;
    private float spawnRangeX = 20;
    private float spawnPositionZ = 20;


    public void SpawnEnnemi()
    {
        _spawnEnnemi = true; // "S" keyboard key triggered.
        //Debug.Log("_spawnEnnemi returned value is => " + _spawnEnnemi);
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnEnnemi == true)
        {
            int animalIndex = Random.Range(0,animalPrefabs.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
            Debug.Log("spawnPosition = " + spawnPosition);
            // Fait apparaître les ennemis (animaux) OK !
            Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);

            _spawnEnnemi = false; // Arrête le spawn des ennemis.

        }
    }
}
