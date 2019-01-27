using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public string lookAtTag = "PlayerCamera";

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("PlayerCamera");
        if(target == null) {
            Debug.LogError("No object found with tag " + lookAtTag + ". I cannot stare at something if I don't know what.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }
}
