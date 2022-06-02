using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask stopMovement;
    [SerializeField]
    float rayLength = 1.4f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            if(!Physics.Raycast(transform.position, Vector3.forward, rayLength, stopMovement))
            {
                StartCoroutine(MovePlayer(Vector3.forward));
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            if(!Physics.Raycast(transform.position, Vector3.back, rayLength, stopMovement))
            {
                StartCoroutine(MovePlayer(Vector3.back));
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            if(!Physics.Raycast(transform.position, Vector3.left, rayLength, stopMovement))
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            if(!Physics.Raycast(transform.position, Vector3.right, rayLength, stopMovement))
            {
                StartCoroutine(MovePlayer(Vector3.right));
            }
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

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

        isMoving = false;
    }
}
