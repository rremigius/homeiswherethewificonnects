using UnityEngine;

public class Stabilize : MonoBehaviour
{
    public float stability;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 torqueVector = Vector3.Cross(transform.up, Vector3.up);
        body.AddTorque(torqueVector * stability);
    }
}
