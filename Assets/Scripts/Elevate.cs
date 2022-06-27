using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    // private RaycastHit hit;
    private GameObject player;
    private float timeToMove = 0.5f;
    bool isUp = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUp){
            if(Vector3.Distance(player.transform.position, transform.position)<=1.1 && player.transform.position.y - transform.position.y == 1)
            {
                if (player.GetComponent<PlayerController>().isMoving == false){
                    player.GetComponent<PlayerController>().isMoving = true;
                    StartCoroutine(Move(Vector3.up,true));
                    isUp=true;
                    player.GetComponent<PlayerController>().isMoving = false;
                }
            }
        }
        if (isUp && Vector3.Distance(player.transform.position, transform.position)>1.5){

            
                StartCoroutine(Move(Vector3.down,false));
                // player.transform.Translate(Vector3.up);
                isUp=false;
            
        }

    }
    private IEnumerator Move(Vector3 direction, bool withplayer) // move block and player, if withplayer == false , without moving player
    {

        float elapsedTime = 0;
        Vector3 block_originPos = transform.position;
        Vector3 block_targetPos = block_originPos + direction;   
        Vector3 player_originPos = player.transform.position;
        Vector3 player_targetPos = player_originPos + direction;
        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(block_originPos, block_targetPos, (elapsedTime / timeToMove));
            if (withplayer) player.transform.position = Vector3.Lerp(player_originPos, player_targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = block_targetPos;
        if (withplayer) player.transform.position = player_targetPos;
    }
}
