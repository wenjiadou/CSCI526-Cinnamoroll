using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    private Vector3 originPos, targetPos;
    private float timeToMove = 0.2f;

    public LayerMask stopMovement;
    public float rayLength = 1.4f;
    public Vector3 direction;

    public bool playVictoryAnimation = false;
    public CapsuleCollider destinationTrigger;

    public LayerMask water;
    public LayerMask Ice;
    public Inventory inventory;

    public float originSpeed = 1f;
    public float speedIncrease = 0.5f;
    void Start()
    {
      inventory = gameObject.GetComponent<Inventory>();
    }

    void Update()
    {
    if (Physics.Raycast(transform.position, Vector3.down, rayLength, Ice) && isMoving == false){
        // Debug.Log(111);
        
        Vector3 target = transform.position;
        while (Physics.Raycast(target, Vector3.down, rayLength, Ice)) target = target + direction;
        Debug.Log(target);
        StartCoroutine(SlipOnIce(target));
    }
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
          inventory.CheckFull();
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

    private IEnumerator SlipOnIce(Vector3 target)
    {
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position - new Vector3(0,1,0), direction,out hit,Mathf.Infinity)){
        //     Debug.Log(hit.collider.transform.position);
        // }
        
        // Vector3 target = transform.position + direction;
        
        isMoving = true;
        float elapsedTime = 0;

        // Vector3 originPos = transform.position;
        // targetPos = originPos + direction;
        float speed = originSpeed;
        while(transform.position!=target)
        {   
            speed += speedIncrease;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }

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
        }
    }
}
