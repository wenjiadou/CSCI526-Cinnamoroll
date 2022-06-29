using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public GameObject gate;
    private RaycastHit hit;
    bool isTrigger = false;

    // private float timer = 0f;
    // bool wait = false;

    // Debug used
    // public int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (!isTrigger)
        {
            // only box can push the trigger
            //if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f) && hit.collider.CompareTag("Box"))
            //{
            //    gate.SetActive(false);
            //    isTrigger = true;
            //}

            //if (Physics.Raycast(transform.position, Vector3.up, out hit, 3f)){
            //    gate.SetActive(false);
            //    isTrigger = true;
            //} else if(wait) {
            //    timer += Time.deltaTime;
            //    if(timer >= 0.1f)
            //    {
            //        wait = false;
            //        timer = 0f;
            //        gate.SetActive(true);
            //    }
            //}
            if (Physics.Raycast(transform.position, Vector3.up, out hit, 3f))
            {
                // Debug.Log("isTrigger " + index + " by " + hit.collider.transform.position);
                gate.SetActive(false);
                isTrigger = true;
            }
        }
        else
        {
            if (!Physics.Raycast(transform.position, Vector3.up, out hit, 3f))
            {
                gate.SetActive(true);
                isTrigger = false;
                // wait = true;
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
