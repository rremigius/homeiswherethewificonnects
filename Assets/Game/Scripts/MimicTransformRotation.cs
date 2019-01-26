using UnityEngine;

public class MimicTransformRotation : MonoBehaviour
{
    public GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = myGameObject.transform.rotation;
    }
}
