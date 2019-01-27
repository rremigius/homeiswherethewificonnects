using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;
    public int id = 1;
    public bool HasTaskAssigned = false;
    public bool IsWorkingOnTask { get; private set; }  = false;
    public void LockPlayer() { IsWorkingOnTask = true; isRunning = false; }
    public void UnlockPlayer() { IsWorkingOnTask = false; }
    public GameObject Cap;

    private Color PlayerColor;
    private Animator animator;
    private bool _isRunning;
    private bool isGameOver = false;

    public bool isRunning {
        get => _isRunning;
        set {
            animator.SetBool("Running", value);
            _isRunning = value;
        }
    }

    void Start() {
        animator = GetComponent<Animator>();
        EventBus.OnGameOver += StopPlayer;
        //EventBus.OnNewGame
    }

    // Update is called once per frame
    void Update()
    {
        if ((IsWorkingOnTask == false) && (isGameOver == false))
        {
            MoveCharacter();
        }
        
    }

    void MoveCharacter()
    {
        float hAxis = Input.GetAxis("Horizontal" + id) * speed;
        float vAxis = -Input.GetAxis("Vertical" + id) * speed;

        transform.Translate(hAxis * Time.deltaTime, 0, vAxis * Time.deltaTime, Space.World);

        isRunning = hAxis != 0 || vAxis != 0;
    }
    public void SetPlayerColor(Color newColor)
    {
        PlayerColor = newColor;
        Cap.GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
    }
    public Color GetPlayerColor()
    {
        return PlayerColor;
    }
    void StopPlayer()
    {
        isGameOver = true;
        isRunning = false;
    }

}
