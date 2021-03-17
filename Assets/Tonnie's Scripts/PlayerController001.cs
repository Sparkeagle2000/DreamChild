﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController001 : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public KeyCode fire;
    public KeyCode jump;
    public KeyCode growth;

    private float nextFire;
    public Rigidbody rb;
    public bool onGround=true;
    public bool grow=true;
    public bool normal=false;
    // Start is called before the first frame update
    void Start()
    {
        //rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
            if(Input.GetKeyDown(jump)&&onGround)
            {
                Debug.Log("jumping");
                rb.AddForce(new Vector3(0,7,0), ForceMode.Impulse);
                onGround=false;
            }
                //Attack script for attack
            if (Input.GetKeyDown(fire) && Time.time > nextFire)
            {
                nextFire=Time.time+fireRate;
                Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            }
        if(Input.GetKeyDown(growth))
        {
            if(grow)
            {
                transform.localScale=new Vector3(3,3,3);
                grow=false;
                normal=true;
            }
            else if(normal)
            {
                transform.localScale=new Vector3(1,1,1);
                grow=true;
                normal=false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Floor")
        {
            onGround=true;
        }
    }
}
