using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public int inputID = 1;

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal" + inputID) * speed;
        float vAxis = -Input.GetAxis("Vertical" + inputID) * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }
}