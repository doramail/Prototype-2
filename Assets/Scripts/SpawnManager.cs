using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;

    private bool _spawnEnnemi = false;

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

            // Fait apparaître les ennemis (animaux) OK !
            Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);

            _spawnEnnemi = false; // Arrête le spawn des ennemis.

        }
    }
}
