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
    
    MeshFilter terrain;
    Bounds bounds;
    Bounds boundsWorld;

    void Start() {
        terrain = GetComponent<MeshFilter>();
        bounds = terrain.mesh.bounds;
        boundsWorld = new Bounds(transform.TransformPoint(bounds.center), transform.TransformPoint(bounds.size));

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
        instance.transform.parent = transform;
        instance.transform.localPosition = position;
    }

    public void Generate() {
        float squareSize = boundsWorld.size.x * boundsWorld.size.z;

        foreach(TerrainObject obj in prefabs) {
            if(obj.prefab == null) continue;

            int quantity = (int)(squareSize * obj.density / 1000);

            for(int i = 0; i < quantity; i++) {
                Vector3 position = GetRandomPosition();
                Spawn(obj.prefab, position);
            }
        }
    }
}
