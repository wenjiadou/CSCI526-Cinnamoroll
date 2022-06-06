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
    // Update is called once per frame
    void Start(){
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            if(!Physics.Raycast(transform.position, Vector3.forward, rayLength, stopMovement))
            {
                direction = Vector3.forward;
                RaycastHit hit;

                if (Physics.Raycast(transform.position, direction, out hit, rayLength) && hit.collider.CompareTag("Box")){ // detect box in the direction
                    //push box;
                    if (hit.collider.GetComponent<BoxController>().moveable) StartCoroutine(MovePlayer(direction));
                }
                else {
                    StartCoroutine(MovePlayer(direction));
                }
              
                // if () StartCoroutine(MovePlayer(Vector3.forward));
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
                    if (hit.collider.GetComponent<BoxController>().moveable) StartCoroutine(MovePlayer(direction));
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
                    if (hit.collider.GetComponent<BoxController>().moveable) StartCoroutine(MovePlayer(direction));
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
                    if (hit.collider.GetComponent<BoxController>().moveable) StartCoroutine(MovePlayer(direction));
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
}
