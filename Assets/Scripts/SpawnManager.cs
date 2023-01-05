using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool _fireAction = false;

    public GameObject[] animalPrefabs;
    public int animalIndex;

    public void ProjectileLauch()
    {
        _fireAction = true; // fire action triggered.
        Debug.Log("_fireAction returned value is => " + _fireAction);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_fireAction == true)
            {
                // Fait apparaître les ennemis (animaux)
                Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);
                _fireAction = false; // Arrête le spawn des ennemis.
            }
    }
}
