using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMover : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    void Start()
    {
        transform.rotation=Quaternion.identity;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 2;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
