using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlayer : MonoBehaviour
{
    private bool isMoving = false;
    private float timeToMove = 0.5f;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.DrawLine(transform.position, transform.position + Vector3.up*10, Color.red); 
        // Debug.Log(111);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving){
            if(Physics.Raycast(transform.position, Vector3.forward,out hit,Mathf.Infinity)){
                Debug.Log(hit.collider.name);
                Vector3 targetPos = hit.collider.transform.position - Vector3.forward;
                StartCoroutine(MovePlayer(targetPos));
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving){
            if(Physics.Raycast(transform.position, Vector3.back,out hit,Mathf.Infinity)){
                Debug.Log(hit.collider.name);
                Vector3 targetPos = hit.collider.transform.position - Vector3.back;
                StartCoroutine(MovePlayer(targetPos));
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving){
            if(Physics.Raycast(transform.position, Vector3.left,out hit,Mathf.Infinity)){
                Debug.Log(hit.collider.name);
                Vector3 targetPos = hit.collider.transform.position - Vector3.left;
                StartCoroutine(MovePlayer(targetPos));
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving){
            if(Physics.Raycast(transform.position, Vector3.right,out hit,Mathf.Infinity)){
                Debug.Log(hit.collider.name);
                Vector3 targetPos = hit.collider.transform.position - Vector3.right;
                StartCoroutine(MovePlayer(targetPos));
            }
        }
    }
    private IEnumerator MovePlayer(Vector3 targetPos)
    {
        isMoving = true;

        float elapsedTime = 0;

        Vector3 originPos = transform.position;
        // targetPos = originPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
