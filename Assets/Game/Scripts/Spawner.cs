using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T:MonoBehaviour
{
    [Tooltip("Spawn a number of instances on start.")]
    public int spawnOnStart = 0;

    [Tooltip("A list of prefabs that can be spawned.")]
    public List<T> prefabs;

    [Tooltip("A list of locations where the spawned objects can be placed.")]
    public List<Transform> locations;

    [Tooltip("The parent transform to attach the spawned object to.")]
    public Transform parent;

    [Tooltip("The distance for each dimension in which the position can be randomly chosen.")]
    public Vector3 randomArea;

    int next = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnOnStart > 0) {
            Spawn(spawnOnStart);
        }
        Init();
    }
    virtual protected void Init() {

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

    Vector3 RandomPosition(Vector3 area) {
        return new Vector3(
            Random.Range(-area.x, area.x), 
            Random.Range(-area.y, area.y),
            Random.Range(-area.z, area.z)
        );
    }

    protected virtual void AfterSpawn(T spawned, int index) {}

    public List<T> Spawn(int count = 1) {
        if(prefabs.Count == 0) {
            Debug.LogError("Cannot spawn. No prefabs specified.");
            return null;
        }
        
        List<T> spawned = new List<T>();
        for(int i = 0; i < count; i++) {
            // Create the new object under the given parent
            T newObj = CreateNewObject();
            newObj.transform.parent = parent;
            
            // First pick a location
            Transform location = GetNewLocation();
            newObj.transform.position = location.position;

            // Then apply random (local) noise
            newObj.transform.localPosition += RandomPosition(randomArea);

            // Make implementation-specific changes
            AfterSpawn(newObj, next++);
            spawned.Add(newObj);
        }

        return spawned;
    }
}
