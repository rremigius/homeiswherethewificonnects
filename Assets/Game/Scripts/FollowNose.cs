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
            velocity.y = 0;
            Debug.Log(velocity);
            Vector3 direction = velocity.normalized;
            transform.rotation = Quaternion.LookRotation(direction);
        }
        previousPosition = transform.position;
    }
}
