using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Transform> locations;

    public bool randomizePrefabs = false;
    public bool randomizeLocations = false;

    public Vector3 randomLocationArea;

    int next = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn() {
        if(prefabs.Count == 0) {
            Debug.LogError("Cannot spawn. No prefabs specified.");
            return;
        }
        next = next % prefabs.Count;
        GameObject newObj = Instantiate(prefabs[next]);
    }
}
