using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombItem : MonoBehaviour
{
    // player position
    private Transform player;
    // Bomb-use
    public GameObject bombItem;

    private Vector3 slot1;
    private Vector3 slot2;
    private Vector3 slot3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot1 = GameObject.Find("Slot(1)").transform.position;
            if(transform.position == slot1)
            {
                Use();
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha2)) {
            slot2 = GameObject.Find("Slot(2)").transform.position;
            if(transform.position == slot2)
            {
                Use();
            }
        } else if(Input.GetKeyDown(KeyCode.Alpha3)) {
            slot3 = GameObject.Find("Slot(3)").transform.position;
            if(transform.position == slot3)
            {
                Use();
            }
        }
    }

    public void Use()
    {
        Instantiate(bombItem, player.position, Quaternion.identity);

        // Destroy the button
        Destroy(gameObject);
    }
}
