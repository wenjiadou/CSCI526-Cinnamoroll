using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Vector3 originPos, targetPos;
    // private float timeToMove = 0.2f;
    private bool move = false;
    private int direction;
    private Vector3 moveDirection;

    void Start()
    {
        // Debug.Log("Hi! Let's start the game!");
    }

    void Update()
    {
        if(move)
        {
            // Debug.Log("Now move the box!");
            // StartCoroutine(MoveBox(Vector3.forward));

            if(direction == 1)
            {
                moveDirection = Vector3.forward;
            }
            if(direction == 2)
            {
                moveDirection = Vector3.back;
            }
            if(direction == 3)
            {
                moveDirection = Vector3.left;
            }
            if(direction == 4)
            {
                moveDirection = Vector3.right;
            }

            originPos = transform.position;
            targetPos = originPos + moveDirection;
            transform.position = targetPos;
            move = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("something hits!");
        if(other.gameObject.tag == "Player")
        {
            // Debug.Log("Oh it is player!");
            move = true;
            direction = other.gameObject.GetComponent<PlayerController>().direction;
        }
    }

    // Both rigidbody, collider not in trigger 
    // void OnCollisionEnter(Collision collision){
    //     if (collision.collider.tag == "Player") {
    //         move = true;
    //         Debug.Log("Hits by player!");
    //     }
    // }

    // private IEnumerator MoveBox(Vector3 direction)
    // {
    //     float elapsedTime = 0;

    //     originPos = transform.position;
    //     targetPos = originPos + direction;

    //     while(elapsedTime < timeToMove)
    //     {
    //         transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    //     transform.position = targetPos;

    //     move = false;
    // }
}
