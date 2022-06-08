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
    public Vector3 direction;

    public bool playVictoryAnimation = false;
    public CapsuleCollider destinationTrigger;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.W) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.forward, rayLength, stopMovement)) // bound check
          {
              direction = Vector3.forward;
              RaycastHit hit;

              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){ // detect box in the direction
                  //push box;
                  PushBox(hit);
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if (Input.GetKeyDown(KeyCode.S) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.back, rayLength, stopMovement))
          {
              direction = Vector3.back;
              RaycastHit hit;

              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
                  PushBox(hit);
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if (Input.GetKeyDown(KeyCode.A) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.left, rayLength, stopMovement))
          {
              direction = Vector3.left;
              RaycastHit hit;

              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
                  PushBox(hit);
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
          }
      }
      if (Input.GetKeyDown(KeyCode.D) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.right, rayLength, stopMovement))
          {
              direction = Vector3.right;
              RaycastHit hit;
              if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){
                  //push box;
                  PushBox(hit);
              }
              else {
                  StartCoroutine(MovePlayer(direction));
              }
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

    private void PushBox(RaycastHit hit)
    {
        // check if it is moveable and push box
        hit.collider.GetComponent<BoxController>().checkMoveable(direction);
        if (hit.collider.GetComponent<BoxController>().moveable)
        {
            StartCoroutine(MovePlayer(direction));
            hit.collider.GetComponent<BoxController>().move = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player is inside destination trigger play victory clip
        if (other == destinationTrigger)
        {
            playVictoryAnimation = true;
            gameObject.SetActive(false);
        }
    }
}
