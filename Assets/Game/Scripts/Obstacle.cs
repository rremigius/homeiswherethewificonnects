using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour
{
    public float damage = 1;

    void OnCollisionEnter(Collision collision) {
        Van van = collision.gameObject.GetComponent<Van>();
        if(van != null) {
            van.ApplyDamage(damage);
            EventBus.FireVanDamaged(van, this, damage);
        }
    }
}
