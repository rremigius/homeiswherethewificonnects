using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public Color PlayerColor = new Color(1, 0, 0, 1);
<<<<<<< HEAD
    public int inputID = 1;
=======
    public bool IsBusy { get; private set; }  = false;
    public void LockPlayer() { IsBusy = true; }
    public void UnlockPlayer() { IsBusy = false; }
>>>>>>> 2df4210e3579babb8ce98cdef3ce37cd1cb09cb6

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        float hAxis = Input.GetAxis("Horizontal" + inputID) * speed;
        float vAxis = -Input.GetAxis("Vertical" + inputID) * speed;
=======
        if (IsBusy == false) { MoveCharacter(); }
        
    }

    void MoveCharacter()
    {
        float hAxis = Input.GetAxis("Horizontal") * speed;
        float vAxis = Input.GetAxis("Vertical") * speed;
>>>>>>> 2df4210e3579babb8ce98cdef3ce37cd1cb09cb6

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }

    void SetPlayerColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }

}
