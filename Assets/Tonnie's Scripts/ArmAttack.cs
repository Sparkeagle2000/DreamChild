using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAttack : MonoBehaviour
{
    public bool end=true;
    public Vector3 start,targetUp,targetForward,up,forward,move1, move2, move3;
    public Transform target1, target2,target3;
    
    // Start is called before the first frame update
    void Start()
    {
        up=transform.rotation.eulerAngles;
        up.x-=40;
        forward=transform.rotation.eulerAngles;
        move1=target1.position-target3.position;
        move2=target2.position-target1.position;
        move3=target1.position-target2.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&end)
        {
            end=false;
            Debug.Log("pressing mouse");
            Attack();
        }
    }

    void Attack()
    {
        float time=0;
        while(time<3.0f)
        {
            time+=Time.deltaTime;
            transform.position+=move1*Time.deltaTime/3;
            transform.Rotate(target1.eulerAngles*Time.deltaTime/3);
        }
        if(time>=3.0f)
        {
            Attack2();
        }
        
    }

    void Attack2()
    {
        float time=0;
        while(time<3.0f)
        {
            time+=Time.deltaTime;
            transform.position+=move2*Time.deltaTime/3;
            transform.Rotate(target2.eulerAngles*Time.deltaTime/3);
        }
        if(time>=3.0f)
        {
            Attack3();
        }
        
    }

    void Attack3()
    {
        float time=0;
        while(time<3.0f)
        {
            time+=Time.deltaTime;
            transform.position+=move3*Time.deltaTime/3;
        }
        if(time>=3.0f)
        {
            end=true;
        }
    }
}
