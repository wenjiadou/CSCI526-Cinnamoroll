// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Elevate : MonoBehaviour
// {
//     private RaycastHit hit;
//     private GameObject player;
//     bool isUp = false;
//     // Start is called before the first frame update
//     void Start()
//     {
//         player = GameObject.Find("Player");
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (!isUp&&player.GetComponent<PlayerController>().isMoving == false){
//             // Debug.Log("test");
//             // if(Vector3.Distance(player.transform.position,transform.position + new Vector3(0,1,0))<0.1){
//             //     Debug.Log("player");
//             // }
//             if (Physics.Raycast(transform.position, Vector3.up, out hit, 1.2f) && hit.collider.CompareTag("Player")){
//                 // elavete up
//
//                 transform.Translate(Vector3.up);
//                 hit.collider.transform.Translate(Vector3.up);
//                 isUp = true;
//             }
//
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject player;
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
                    transform.Translate(Vector3.up);
                    player.transform.Translate(Vector3.up);
                    isUp=true;
                }
            }
        }
        if (isUp && Vector3.Distance(player.transform.position, transform.position)>1.5){

            if (player.GetComponent<PlayerController>().isMoving == false){
                transform.Translate(Vector3.down);
                // player.transform.Translate(Vector3.up);
                isUp=false;
            }
        }

    }
}
