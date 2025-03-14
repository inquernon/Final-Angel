using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulsador : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
        rb.angularVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
