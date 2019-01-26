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
        if(Mathf.Abs(velocity.x) > 0.01f || Mathf.Abs(velocity.z) > 0.01f) {
            velocity.y = 0;
            transform.rotation = Quaternion.LookRotation(velocity);
        }
        previousPosition = transform.position;
    }
}
