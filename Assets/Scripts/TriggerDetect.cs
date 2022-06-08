using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    public GameObject gate;
    private RaycastHit hit;
    bool isTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTrigger){
            if (Physics.Raycast(transform.position, Vector3.up, out hit, 10f) && hit.collider.CompareTag("Box")){
                gate.SetActive(false);
                isTrigger = true;
            }
            
        }
        
    }
}
