using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public GameObject gate;
    private RaycastHit hit;
    bool isTrigger = false;

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
            }
        } else {
          if (!Physics.Raycast(transform.position, Vector3.up, out hit, 10f)){
              gate.SetActive(true);
              isTrigger = false;
          }
        }

    }
}
