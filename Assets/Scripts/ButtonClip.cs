using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClip : MonoBehaviour
{
    public GameObject bridge;
    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            bridge.SetActive(true);
        }
    }
}
