using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private GameObject player;
    private HeartSystem playerHearts;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHearts = player.GetComponent<HeartSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("hit something!");
        if(other.CompareTag("Player")) {
            Debug.Log("explode: player");
            playerHearts.TakeDamage();
        }

        if(other.CompareTag("Enemy")) {
            Debug.Log("explode: enemy");
            Destroy(other.gameObject);
        }
    }
}
