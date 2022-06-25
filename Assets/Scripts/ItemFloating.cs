using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemFloating : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {

    startPos = transform.position;
    transform.DOPath(new Vector3[] {
    startPos, transform.position + new Vector3(0, 0.5f, 0), startPos }, 2)//Vector3.up//new Vector3(0,0.5f,0)
    .SetLoops(-1, LoopType.Restart);
    transform.DOBlendableLocalRotateBy(new Vector3(0, 360, 0), 4f, RotateMode.FastBeyond360)//.DORotate(new Vector3(0, 360, 45), 3f, RotateMode.WorldAxisAdd)
    .SetLoops(-1, LoopType.Restart);//循环设置为-1为一直
    }
    //销毁写在人物里面，背包满了道具碰到不销毁
    
}
