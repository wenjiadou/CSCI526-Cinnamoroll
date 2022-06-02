/*
 * Copyright (c) 2015 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


using UnityEngine;
using System.Collections;

/// <summary>
/// Small script for easily destroying an object after a while
/// </summary>
public class DestroySelf : MonoBehaviour {
    public float Delay = 3f; //Delay in seconds before destroying the gameobject
    private RaycastHit hit;
    void Start() {
        Destroy(gameObject, Delay);
    }
    // void Update(){
    //     Physics.Raycast(transform.position + new Vector3(0,.5f,0), Vector3.forward, out hit,0.5f);
    //     if (hit.collider && hit.collider.gameObject.CompareTag("Enemy")){
    //         Destroy(hit.collider.gameObject);
    //     }
    //     Physics.Raycast(transform.position + new Vector3(0,.5f,0), Vector3.back, out hit,0.5f);
    //     if (hit.collider && hit.collider.gameObject.CompareTag("Enemy")){
    //         Destroy(hit.collider.gameObject);
    //     }
    //     Physics.Raycast(transform.position + new Vector3(0,.5f,0), Vector3.left, out hit,0.5f);
    //     if (hit.collider && hit.collider.gameObject.CompareTag("Enemy")){
    //         Destroy(hit.collider.gameObject);
    //     }
    //     Physics.Raycast(transform.position + new Vector3(0,.5f,0), Vector3.right, out hit,0.5f);
    //     if (hit.collider && hit.collider.gameObject.CompareTag("Enemy")){
    //         Destroy(hit.collider.gameObject);
    //     }
    // }
}
