using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public Transform[] waypoints;

    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoints[i].transform.position)
        {
            i += 1;
        }

        if (i == waypoints.Length)
        {
            i = 0;
        }
    }
  
    
}
