using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public GameObject gate;
    private RaycastHit hit;
    bool isTrigger = false;

    private float timer = 0f;
    bool wait = false;

    // Update is called once per frame
    void Update()
    {
        if (!isTrigger){
            // only box can push the trigger
            // if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f) && hit.collider.CompareTag("Box")){
            //     gate.SetActive(false);
            //     isTrigger = true;
            // }

            if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f)){
                gate.SetActive(false);
                isTrigger = true;
            } else if(wait) {
                timer += Time.deltaTime;
                if(timer >= 0.3f)
                {
                    wait = false;
                    timer = 0f;
                    gate.SetActive(true);
                }
            }
        } else {
          if (!Physics.Raycast(transform.position, Vector3.up, out hit, 10f)){
              // gate.SetActive(true);
              isTrigger = false;
              wait = true;
          }
        }

        // if(wait) {
        //     timer += Time.deltaTime;
        //     if(timer >= 1f)
        //     {
        //         wait = false;
        //         timer = 0f;
        //         gate.SetActive(true);
        //     }
        // }
    }
}
