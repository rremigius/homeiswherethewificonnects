using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class BalancePlatform : MonoBehaviour
{
    public Collider tiltLimits;
    public Rigidbody applyForceTo;
    private float force = 0.5f;

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

    float AngleFrom0(float angle) {
        return angle < 180 ? angle : angle-360;
    }

    void ApplyForce() {
        if(applyForceTo) {
            Vector3 tilt = transform.rotation.eulerAngles;
            Vector3 direction = new Vector3(-AngleFrom0(tilt.z), 0, AngleFrom0(tilt.x));
            applyForceTo.AddForce(direction * force);
        }
    }
}
