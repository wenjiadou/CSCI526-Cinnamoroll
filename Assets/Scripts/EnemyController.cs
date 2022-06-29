using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2;
    public Transform[] waypoints;
    public bool moveEnemy;

    // public bool afterAttack;
    // private float timer = 0f;

    private int i = 0;
    private int lastI = 0;
    private bool moveForward = true;
    private Vector3 moveDirection;
    public LayerMask boxLayer;

    void Update()
    {
        if(moveEnemy)
        {

          if(moveForward && transform.position == waypoints[i].transform.position)
          {
              lastI = i;
              i += 1;
              if (i == waypoints.Length)
              {
                  i = 0;
              }
          } else if(!moveForward && transform.position == waypoints[i].transform.position) {
              lastI = i;
              i -= 1;
              if (i == -1)
              {
                  i = waypoints.Length - 1;
              }
          } else {
              moveDirection = (waypoints[i].transform.position - transform.position).normalized;
              if(Physics.Raycast(transform.position, moveDirection, 0.5f, boxLayer))
              {
                  // detects box
                  if(moveForward)
                  {
                      i -= 1;
                      if (i == -1)
                      {
                          i = waypoints.Length - 1;
                      }
                  } else {
                      i += 1;
                      if (i == waypoints.Length)
                      {
                          i = 0;
                      }
                  }
                  moveForward = !moveForward;
              } else {
                  // normally moves
                  transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, speed * Time.deltaTime);
              }
          }

            // if(afterAttack)
            // {
            //     // After attacks player, enemy will stop for 3s
            //     // timer += Time.deltaTime;
            //     // if(timer >= 3f)
            //     // {
            //     //     afterAttack = false;
            //     //     timer = 0f;
            //     // }
            // } else {
            //     if(moveForward && transform.position == waypoints[i].transform.position)
            //     {
            //         lastI = i;
            //         i += 1;
            //         if (i == waypoints.Length)
            //         {
            //             i = 0;
            //         }
            //     } else if(!moveForward && transform.position == waypoints[i].transform.position) {
            //         lastI = i;
            //         i -= 1;
            //         if (i == -1)
            //         {
            //             i = waypoints.Length - 1;
            //         }
            //     } else {
            //         moveDirection = (waypoints[i].transform.position - transform.position).normalized;
            //         if(Physics.Raycast(transform.position, moveDirection, 0.5f, boxLayer))
            //         {
            //             // detects box
            //             if(moveForward)
            //             {
            //                 i -= 1;
            //                 if (i == -1)
            //                 {
            //                     i = waypoints.Length - 1;
            //                 }
            //             } else {
            //                 i += 1;
            //                 if (i == waypoints.Length)
            //                 {
            //                     i = 0;
            //                 }
            //             }
            //             moveForward = !moveForward;
            //         } else {
            //             // normally moves
            //             transform.position = Vector3.MoveTowards(transform.position, waypoints[i].transform.position, speed * Time.deltaTime);
            //         }
            //     }
            // }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<HeartSystem>().TakeDamage();
            // afterAttack = true;
        }
    }
}
