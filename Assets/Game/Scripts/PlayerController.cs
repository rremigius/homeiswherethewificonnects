using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    private Color PlayerColor;
  

    public int id = 1;
    public bool HasTaskAssigned = false;
    public bool IsWorkingOnTask { get; private set; }  = false;
    public void LockPlayer() { IsWorkingOnTask = true; }
    public void UnlockPlayer() { IsWorkingOnTask = false; }

    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {

        float hAxis = Input.GetAxis("Horizontal" + id) * speed;
        float vAxis = -Input.GetAxis("Vertical" + id) * speed;



        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);
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
