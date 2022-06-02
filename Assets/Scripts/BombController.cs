using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private bool canDropBombs;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        canDropBombs = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDropBombs && Input.GetKeyDown(KeyCode.Space)){
            DropBomb();
            canDropBombs = false;
        }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Bomb") {
            GameObject gameObj = collision.collider.gameObject;
            // ObjectItem obj = (ObjectItem)gameObj.GetComponent<ObjectItem>();
            // if (obj!=null){
            //     obj.isChecked = true;
            //     obj = package.getItem(obj);
            //     if (obj.count == 0){
            //         Destroy(gameObj);
            //     }
            // }
            canDropBombs = true;
            Destroy(gameObj);
        }
    }
    private void DropBomb(){
       
        if (bombPrefab){
            // Debug.Log("111");
            Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
            
        }
        else {
            Debug.Log("No more bombs");
        }
    }
}
