using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Vector3 originPos, targetPos;
    // private float timeToMove = 0.2f;
    private bool move = false;
    private Vector3 direction;
    // private Vector3 moveDirection;
    public LayerMask stopMovement;
    float rayLength = 1.4f;
    public bool moveable = true;
    public GameObject upBox;
    void Start()
    {
        // Debug.Log("Hi! Let's start the game!");
    }

    void Update()
    {
        checkMoveable(direction);
        if(move && moveable)
        {
            // originPos = transform.position;
            // targetPos = originPos + direction;
            // transform.position = targetPos;
            transform.Translate(direction);
            bool isDown = downsideDetect();
            if (isDown == false){
                transform.Translate(Vector3.down);
            }
            if (upBox!=null) {
                upBox.transform.Translate(direction);
                if (isDown == false) upBox.transform.Translate(Vector3.down);
            }
            move = false;
        }
        
    }
    bool downsideDetect(){

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, rayLength)){
            return false;
        }
        else return true;
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
    void checkMoveable(Vector3 direction){
        moveable = !Physics.Raycast(transform.position+new Vector3(0,0.5f,0), direction, rayLength, stopMovement) && !Physics.Raycast(transform.position+new Vector3(0,0.5f,0), direction, rayLength);
    }

}