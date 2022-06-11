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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        Instantiate(bombItem, player.position, Quaternion.identity);

        // Destroy the button
        Destroy(gameObject);
    }
}
