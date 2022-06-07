using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public Transform[] waypoints;
    public bool moveEnemy;

    private int i = 0;

    void Update()
    {
        if(moveEnemy)
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<HeartSystem>().TakeDamage();
        }
    }
}
