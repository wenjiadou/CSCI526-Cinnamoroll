using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Enemies")){
            HealthManager.health --;
            if(HealthManager.health <= 0){
            }
            else{
                StartCoroutine(GetDamaged());
            }
        }
    }
    
    IEnumerator GetDamaged(){
        Physics.IgnoreLayerCollision(6,8);
        yield return new WaitForSeconds(1);
        Physics.IgnoreLayerCollision(6,8, false);
    }

}
