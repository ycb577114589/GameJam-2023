using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
 
public class MoveItem: MonoBehaviour
{
    public Transform routeTrans;
    public int moveSpeed = 0;
    public void Start()
    {
        routeTrans = gameObject.GetComponent<Transform>();
    }
} 
