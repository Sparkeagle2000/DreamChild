﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlocks : MonoBehaviour
{
    Vector3 up, down;
    float speed=0.0f;
    bool forward=true,back=false;
    // Start is called before the first frame update
    void Start()
    {
        up=new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
        down=new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(speed<0.8f)
        {
            speed+=Time.deltaTime/2;
        }
        if(forward)
        {
            transform.position = Vector3.Lerp (transform.position,new Vector3(up.x,up.y,up.z), Time.deltaTime * speed);
            if (Vector3.Distance (transform.position, up) < 0.1 )
            {
                forward = false;
                back=true;
                speed=0.0f;
            }
        }
        if(back)
        {
            transform.position = Vector3.Lerp (transform.position,new Vector3(down.x,down.y,down.z), Time.deltaTime * speed);
            if (Vector3.Distance (transform.position, down) < 0.1 )
            {
                forward = true;
                back=false;
                speed=0.0f;
            }
        }
    }
}