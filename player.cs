using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    float xVal, yVal;
    float moveSpeed = 5f;
    
    public static float healthVal;
    // Start is called before the first frame update
    void Start()
    {
        healthVal = 0.11f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xVal = Input.GetAxis("Horizontal") * moveSpeed;
        yVal = Input.GetAxis("Vertical")* moveSpeed;
        if(healthVal <=0){
            Destroy(gameObject);
        }

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(xVal, yVal);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name.Equals("enemy")){
            healthVal -=0.02f;
        }
        
    }

}
