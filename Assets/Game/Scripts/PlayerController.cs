using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public Color PlayerColor = new Color(1, 0, 0, 1);
    public int inputID = 1;
    public bool IsBusy { get; private set; }  = false;
    public void LockPlayer() { IsBusy = true; }
    public void UnlockPlayer() { IsBusy = false; }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxis("Horizontal" + inputID) * speed;
        float vAxis = -Input.GetAxis("Vertical" + inputID) * speed;

        if (IsBusy == false) { MoveCharacter(); }
        
    }

    void MoveCharacter()
    {
        float hAxis = Input.GetAxis("Horizontal") * speed;
        float vAxis = Input.GetAxis("Vertical") * speed;


        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }

    void SetPlayerColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }

}
