using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityScript.Lang;

public class Waypoints : MonoBehaviour
{
    // if pathfinding doesnt work we will use waypoints
    // Use this for initialization
    public GameObject[] waypoints;
    int Target;
    public float speed;
    public bool playerspotted = false;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Target = 0;

    }

    // Update is called once per frame
    void Update()
        
    { 



        //- enemy           - waypoint                         -distance       -not at max
        if (Vector3.Distance(transform.position, waypoints[Target].transform.position) < 0.01  && playerspotted==false )
        {
            
            Target++;
            
            if (Target == waypoints.Length)
            {

                Debug.Log(Target + ">>>" + waypoints.Length);
                Target = 0;
            }


        }
        else if (playerspotted == true)
        {
           
            
            transform.position= Vector3.MoveTowards(this.transform.position, waypoints[Target].transform.position, speed-10);
            
            
                
            
            Debug.Log("gg");
        }
        else
        {
            
            
            transform.position = Vector3.MoveTowards(transform.position, waypoints[Target].transform.position, speed * Time.deltaTime);
        }


        

    }
   
}

