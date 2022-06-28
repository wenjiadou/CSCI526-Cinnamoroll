using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask stopMovement;
    public float rayLength = 1.4f;
    public Vector3 direction;

    // used in SingleLevel
    public bool playVictoryAnimation = false;
    public CapsuleCollider destinationTrigger;

    public LayerMask water;

    public Inventory inventory;

    public int currentLevel = 0;
    public int enemyKill = 0;
    public int itemPickup = 0;

    void Start()
    {
      inventory = gameObject.GetComponent<Inventory>();
    }

    void Update()
    {
      if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.forward, rayLength, (stopMovement | water)))
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
      if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.back, rayLength, (stopMovement | water)))
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
      if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.left, rayLength, (stopMovement | water)))
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
      if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && !isMoving)
      {
          if(!Physics.Raycast(transform.position, Vector3.right, rayLength, (stopMovement | water)))
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
          // inventory.CheckFull();
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
        // // check if it is moveable and push box
        // hit.collider.GetComponent<BoxController>().checkMoveable(direction);
        // if (hit.collider.GetComponent<BoxController>().moveable)
        // {
        //     StartCoroutine(MovePlayer(direction));
        //     hit.collider.GetComponent<BoxController>().move = true;
        // }

        // check if it is moveable and push box
        bool moveable = hit.collider.GetComponent<BoxController>().checkMoveable(direction);
        if (moveable) {
            StartCoroutine(MovePlayer(direction));
            hit.collider.GetComponent<BoxController>().moveBox(direction);
            hit.collider.GetComponent<BoxController>().limitSteps--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player is inside destination trigger play victory clip
        if (other == destinationTrigger)
        {
            playVictoryAnimation = true;
            gameObject.SetActive(false);

            Analytics.CustomEvent("UserData", new Dictionary<string, object>{{"Kill", enemyKill}, {"Item", itemPickup}});
        }
    }
}
