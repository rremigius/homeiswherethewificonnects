using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNose : MonoBehaviour
{
    Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = transform.position - previousPosition;
        if(velocity.x > 0 || velocity.z > 0) {
            // Vector3 direction = Quaternion.Euler(Quaternion.LookRotation(velocity.normalized))
            // direction.y = 0;
            // transform.transform.rotation = 
        }
    }
}
