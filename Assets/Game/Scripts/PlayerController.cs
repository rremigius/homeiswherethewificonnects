using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public bool IsBusy { get; private set; }  = false;
    public void LockPlayer() { IsBusy = true; }
    public void UnlockPlayer() { IsBusy = false; }

    // Update is called once per frame
    void Update()
    {
        if (IsBusy == false) { MoveCharacter(); }
        
    }

    void MoveCharacter()
    {
        float hAxis = Input.GetAxis("Horizontal") * speed;
        float vAxis = Input.GetAxis("Vertical") * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
    }



}
