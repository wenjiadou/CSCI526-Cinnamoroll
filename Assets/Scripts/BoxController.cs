using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Vector3 direction;
    public LayerMask stopMovement;
    float rayLength = 1.4f;
    public bool moveable = true;
    public GameObject upBox;

    void Update()
    {
      
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

    public bool checkMoveable(Vector3 direction)
    {
        return !Physics.Raycast(transform.position, direction, rayLength, stopMovement) && !Physics.Raycast(transform.position, direction, rayLength);
    }

    public void moveBox(Vector3 direction){
        transform.Translate(direction);
        bool isDown = downsideDetect();
        if (isDown == false){
            transform.Translate(Vector3.down);
        }
        if (upBox!=null) {
            upBox.transform.Translate(direction);
            if (isDown == false) upBox.transform.Translate(Vector3.down);
        }
    }
}
