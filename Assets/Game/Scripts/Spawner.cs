using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Transform> locations;
    public Transform parent;

    int next = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject CreateNewObject() {
        int objIndex = next % prefabs.Count;
        return Instantiate(prefabs[objIndex]);
    }

    Transform GetNewLocation() {
        int locationIndex = next % locations.Count;
        return locations[locationIndex];
    }

    protected virtual void AfterSpawn(GameObject gameObject, int index) {}

    public List<GameObject> Spawn(int count = 1) {
        if(prefabs.Count == 0) {
            Debug.LogError("Cannot spawn. No prefabs specified.");
            return null;
        }
        
        List<GameObject> spawned = new List<GameObject>();
        for(int i = 0; i < count; i++) {
            GameObject newObj = CreateNewObject();
            Transform location = GetNewLocation();
            newObj.transform.parent = parent;
            newObj.transform.position = location.position;

            spawned.Add(newObj);
        }

        return spawned;
    }
}
