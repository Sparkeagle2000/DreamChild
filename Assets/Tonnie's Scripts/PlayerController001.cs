using System.Collections;
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

    private float nextFire;
    public Rigidbody rb;
    public bool onGround=true;
    public bool growth=true;
    public bool normal=false;
    public float count=5.0f;

    private TimeManager timemanager;
    // Start is called before the first frame update
    void Start()
    {
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        rb=GetComponent<Rigidbody>();
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
            //if (Input.GetKeyDown(fire) && Time.time > nextFire)
            //{
            //    nextFire=Time.time+fireRate;
            //    Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            //}
        
        /*if(Input.GetKeyDown(KeyCode.F))
        {
            if(growth)
            {
                transform.localScale=new Vector3(3,3,3);
                growth=false;
                normal=true;
            }
            else if(normal)
            {
                transform.localScale=new Vector3(1,1,1);
                normal=false;
                growth=true;
            }
        }*/

        if(Input.GetKeyDown(KeyCode.F)&& !timemanager.TimeIsStopped) 
        {
            timemanager.StopTime();

        }
        else if(Input.GetKeyDown(KeyCode.F) && timemanager.TimeIsStopped) 
        {
            timemanager.ContinueTime();

        }   
        if(count<=0.0f)
        {
            timemanager.ContinueTime();
        }
        if(!timemanager.TimeIsStopped) 
        {
            count+=Time.deltaTime;

        }
        if(timemanager.TimeIsStopped) 
        {
            count-=Time.deltaTime;

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
