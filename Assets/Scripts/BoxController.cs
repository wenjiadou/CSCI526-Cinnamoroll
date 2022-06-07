using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool move = false;
    private Vector3 direction;
    public LayerMask stopMovement;
    float rayLength = 1.4f;
    public bool moveable = true;
    public GameObject upBox;

    void Update()
    {
      if(move)
      {
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            move = true;
            direction = other.gameObject.GetComponent<PlayerController>().direction;
        }
    }

    bool downsideDetect()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, rayLength))
        {
            return false;
        }
        else return true;
    }

    public void checkMoveable(Vector3 direction)
    {
        moveable = !Physics.Raycast(transform.position, direction, rayLength, stopMovement) && !Physics.Raycast(transform.position, direction, rayLength);
    }
}
