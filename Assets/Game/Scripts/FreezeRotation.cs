using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRotation : MonoBehaviour
{
    public bool freezeX = false;
    public bool freezeY = false;
    public bool freezeZ = false;

    Vector3 startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;
        
        if(freezeX) {
            rotation.x = startRotation.x;
        }
        if(freezeY) {
            rotation.y = startRotation.y;
        }
        if(freezeZ) {
            rotation.z = startRotation.z;
        }

        transform.rotation = Quaternion.Euler(rotation);
    }
}
