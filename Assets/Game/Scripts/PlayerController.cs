using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public Color PlayerColor = new Color(1, 0, 0, 1);
    public int id = 1;
    public bool IsBusy { get; private set; }  = false;
    public void LockPlayer() { IsBusy = true; }
    public void UnlockPlayer() { IsBusy = false; }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxis("Horizontal" + id) * speed;
        float vAxis = -Input.GetAxis("Vertical" + id) * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }

    void SetPlayerColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }

}
