using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class BalancePlatform : MonoBehaviour
{
    public Collider tiltLimits;
    public Rigidbody applyForceTo;

    Rigidbody body;
    new Collider collider;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        Assert.IsNotNull(collider);

        Physics.IgnoreCollision(collider, tiltLimits);
    }

    // Update is called once per frame
    void Update() {
        ApplyForce();
    }

    void ApplyForce() {

    }
}
