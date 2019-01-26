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

    bool _isRunning = false;
    public bool isRunning { 
        get => _isRunning; 
        set {
            animator.SetBool("Running", value);
            _isRunning = value;
        }
    }

    Animator animator;

    public Color PlayerColor
    {
        get => PlayerColor;
        set
        {
            GetComponent<MeshRenderer>().material.SetColor("_Color", value);
            PlayerColor = value;
        }
    }

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        float hAxis = Input.GetAxis("Horizontal" + id) * speed;
        float vAxis = -Input.GetAxis("Vertical" + id) * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime);

        isRunning = hAxis != 0 || vAxis != 0;
    }

    public void SetPlayerColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }

}
