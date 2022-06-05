using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    private HeartSystem playerHearts;
    private GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3f);
    }

    void Explode()
    {
        // Debug.Log(gameObject.transform.position);
        explosion = Instantiate(explosionPrefab, transform.position + Vector3.down, Quaternion.identity);
        // Debug.Log(explosion.transform.position);

        // Kill enemy and hurt player
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));

        // Destroy the bomb and the explosion effect
        Destroy(gameObject, .3f);
        Destroy(explosion, .5f);
    }

    private IEnumerator CreateExplosions(Vector3 direction){
        for (int i = 1;i<3;i++){
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0,.5f,0), direction, out hit);
            if (hit.collider.gameObject.CompareTag("Enemy")){
                // Kill enemy
                Destroy(hit.collider.gameObject);
            } else if(hit.collider.gameObject.CompareTag("Player"))
            {
                // Player life - 1
                playerHearts =  hit.collider.gameObject.GetComponent<HeartSystem>();
                playerHearts.TakeDamage();
            } else{
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }
}
