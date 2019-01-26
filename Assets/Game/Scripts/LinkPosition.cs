using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkPosition : MonoBehaviour
{
    public Transform attachTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = attachTo.position;
    }
}
