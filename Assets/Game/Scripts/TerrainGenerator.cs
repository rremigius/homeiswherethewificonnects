using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    [Serializable]
    public class TerrainObject {
        public GameObject prefab;
        public float density = 0;
    }

    public List<TerrainObject> prefabs;
    
    public Transform clearArea;
    public float clearRadius = 5;
    
    MeshFilter meshFilter;
    Bounds bounds;
    Bounds boundsWorld;

    Transform terrainParent;

    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        bounds = meshFilter.mesh.bounds;
        boundsWorld = new Bounds(transform.TransformPoint(bounds.center), transform.TransformPoint(bounds.size));

        GameObject terrain = new GameObject("Terrain");
        terrain.transform.parent = transform;
        terrainParent = terrain.transform;

        terrainParent.transform.localPosition = Vector3.zero;
        terrainParent.transform.localScale = new Vector3(1,1,1);
        terrainParent.transform.rotation = transform.rotation;

        if(clearArea == null) {
            clearArea = transform;
        }

        EventBus.OnNewGame += Reset;

        Generate();
    }

    Vector3 GetRandomPosition() {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = bounds.max.y;
        float z = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(x, y, z);
    }

    void Spawn(GameObject prefab, Vector3 position) {
        GameObject instance = Instantiate(prefab);
        instance.transform.parent = terrainParent;
        instance.transform.localPosition = position;
        instance.transform.rotation = Quaternion.Euler(0, Random.Range(0,359), 0);
    }

    bool IsWithinClearArea(Vector3 position) {
        Vector3 clearPosition = transform.TransformPoint(position);
        float distance = Vector3.Distance(clearArea.position, clearPosition);

        return distance < clearRadius;
    }

    public void Reset() {
        foreach (Transform child in terrainParent) {
            GameObject.Destroy(child.gameObject);
        }
        Generate();
    }

    public void Generate() {
        float squareSize = boundsWorld.size.x * boundsWorld.size.z;

        foreach(TerrainObject obj in prefabs) {
            if(obj.prefab == null) continue;

            int quantity = (int)(squareSize * obj.density / 1000);

            for(int i = 0; i < quantity; i++) {
                Vector3 position = GetRandomPosition();
                if(IsWithinClearArea(position)) {
                    continue;
                }

                Spawn(obj.prefab, position);
            }
        }
    }
}
