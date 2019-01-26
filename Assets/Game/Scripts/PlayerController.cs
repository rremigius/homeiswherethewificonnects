using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public int id = 1;
    public bool HasTaskAssigned = false;
    public bool IsWorkingOnTask { get; private set; }  = false;
    public void LockPlayer() { IsWorkingOnTask = true; }
    public void UnlockPlayer() { IsWorkingOnTask = false; }
    
    private Color PlayerColor;

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        float hAxis = Input.GetAxis("Horizontal" + id) * speed;
        float vAxis = -Input.GetAxis("Vertical" + id) * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime, Space.World);
    }

    public void SetPlayerColor(Color newColor)
    {
        PlayerColor = newColor;
        GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }
    public Color GetPlayerColor()
    {
        return PlayerColor;
    }

}
