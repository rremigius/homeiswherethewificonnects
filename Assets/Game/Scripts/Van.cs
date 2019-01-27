using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Van : MonoBehaviour
{
    public float health = 1;
    
    bool _crashed = false;
    bool crashed { 
        get => _crashed; 
        set { 
            _crashed = value;
            body.isKinematic = crashed;
            if(crashed) {
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
    }

    void OnNewGame() {
        transform.position = startPosition;
        crashed = false;
    }

    public void ApplyDamage(float damage) {
        health -= damage;
        if(health <= 0) {
            crashed = true;
            EventBus.FireVanCrashed(this);
        }
    }
}
