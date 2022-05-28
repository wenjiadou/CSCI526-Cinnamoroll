using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Vector2 checkCenter;
    public float checkDistance = 1.5f;
    public LayerMask PlayerLayer;
    public enum State //箱子状态
    {
        beleftpush,
        berightpush,
        beuppush,
        bedownpush,
        idle,
    }

    public State state;
    private void Start()
    {
        state = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        PhysicCheck();
        PushbyPlayer();
    }

    void PhysicCheck()
    {//检测碰撞
        RaycastHit2D beleftpush = Raycast(checkCenter, Vector2.right, checkDistance, PlayerLayer);//从左往右推
        RaycastHit2D berightpush = Raycast(checkCenter, Vector2.left, checkDistance, PlayerLayer);
        RaycastHit2D beuppush = Raycast(checkCenter, Vector2.down, checkDistance, PlayerLayer);
        RaycastHit2D bedownpush = Raycast(checkCenter, Vector2.up, checkDistance, PlayerLayer);

        if(beleftpush){
            state = State.beleftpush;
        }
        else if(berightpush){
            state = State.berightpush;
        }
        else if(beuppush){
            state = State.beuppush;
        }
        else if(bedownpush){
            state = State.bedownpush;
        }
        else
            state = State.idle;
    }

    void PushbyPlayer()
    {
        switch(state){
            case State.beleftpush:
                {
                    transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
                    break;
                }
            case State.berightpush:
                {
                    transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
                    break;
                }
            case State.beuppush:
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                    break;
                }
            case State.bedownpush:
                {
                   transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                    break;
                }
            default:
                break;            
        }
    }

    
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer) //重载函数
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDiraction * length, color, 0.2f);
        return hit;
    }
}
