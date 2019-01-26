using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BalancePlatform : MonoBehaviour
{
    Rigidbody body;

    public float maxTilt = 45;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Constrain();
    }

    void Constrain() {
        // float torqueX = transform.eulerAngles.x * 10;
        // float torqueZ = transform.eulerAngles.z * 10;
        // body.AddTorque(new Vector3(-torqueX, 0, torqueZ));
    }
}
