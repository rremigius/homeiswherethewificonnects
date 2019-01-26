using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T:MonoBehaviour
{
    public List<T> prefabs;
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

    T CreateNewObject() {
        int objIndex = next % prefabs.Count;
        return Instantiate(prefabs[objIndex].GetComponent<T>());
    }

    Transform GetNewLocation() {
        if(locations.Count == 0) return transform;

        int locationIndex = next % locations.Count;
        return locations[locationIndex];
    }

    protected virtual void AfterSpawn(T spawned, int index) {}

    public List<T> Spawn(int count = 1) {
        if(prefabs.Count == 0) {
            Debug.LogError("Cannot spawn. No prefabs specified.");
            return null;
        }
        
        List<T> spawned = new List<T>();
        for(int i = 0; i < count; i++) {
            T newObj = CreateNewObject();
            Transform location = GetNewLocation();
            newObj.transform.parent = parent;
            newObj.transform.position = location.position;

            AfterSpawn(newObj, next++);
            spawned.Add(newObj);
        }

        return spawned;
    }
}
