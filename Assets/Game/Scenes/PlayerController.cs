using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal") * speed;
        float vAxis = Input.GetAxis("Vertical") * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }
}