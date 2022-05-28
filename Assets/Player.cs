using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed;
    Vector3 movement;
    // Update is called once per frame
    void Update()
    {
        movement = new  Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);
        transform.Translate(movement);
    }
}
