using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Van : MonoBehaviour
{
    public float health = 1;
    
    bool _alive = false;
    public bool alive { 
        get => _alive; 
        set { 
            _alive = value;
            body.isKinematic = !alive;
            if(!alive) {
                body.velocity = Vector3.zero;
                body.angularVelocity = Vector3.zero;
            }
        }
    }

    Rigidbody body;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        startPosition = transform.position;
        EventBus.OnNewGame += OnNewGame;

        alive = false;
    }

    void OnNewGame() {
        transform.position = startPosition;
        alive = true;
    }

    public void ApplyDamage(float damage) {
        health -= damage;
        if(health <= 0) {
            alive = false;
            EventBus.FireVanCrashed(this);
        }
    }
}
