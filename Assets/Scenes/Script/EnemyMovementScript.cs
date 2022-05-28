using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 2;
    public float blockSize = 10;
    public float range = 3;
    private float posX;
    private float posY;
    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if //(transform.position.x >= posX + range && transform.position.y <= posY)
            (transform.position.x < posX && transform.position.y <= posY)
        {
            print("up");
            transform.Translate(Vector2.up * speed * blockSize * Time.deltaTime);
        } else if (transform.position.x >= posX + range && transform.position.y >= posY - range)
        {
            print("down");
            transform.Translate(Vector2.down * speed * blockSize * Time.deltaTime);
        } else if (transform.position.x >= posX && transform.position.y <= posY - range)
        {
            print("left");
            transform.Translate(Vector2.left * speed * blockSize * Time.deltaTime);
        } else if //(transform.position.x <= posX && transform.position.y <= posY)
            (transform.position.x >= posX + range && transform.position.y <= posY)
        {
            print("right");
            transform.Translate(Vector2.right * speed * blockSize * Time.deltaTime);
        }

    }
}
