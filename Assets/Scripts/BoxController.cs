using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // public Transform box;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;
    private bool move = false;

    void Start()
    {
        Debug.Log("Hi! Let's start the game!");
    }

    void Update()
    {
        if(move)
        {
            Debug.Log("Now move the box!");
            StartCoroutine(MoveBox(Vector3.forward));
        }
    }

    void onTriggerEnter(Collider other)
    {
        Debug.Log("something hits!");
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Oh it is player!");
            move = true;
        }
    }

    // Both rigidbody, collider not in trigger 
    // void OnCollisionEnter(Collision collision){
    //     if (collision.collider.tag == "Player") {
    //         move = true;
    //         Debug.Log("Hits by player!");
    //     }
    // }

    private IEnumerator MoveBox(Vector3 direction)
    {
        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        move = false;
    }
}
