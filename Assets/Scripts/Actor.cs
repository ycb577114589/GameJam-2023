using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int max_health;
    private int health;

    private void Start()
    {
        health = max_health;
    }

    private void Update()
    {
        foreach (var selectObj in InputSystem.Instance.SelectObjects())
        {
            if (this.gameObject == selectObj)
            {
                Debug.Log("Click this!!!");
            }
        }
    }
}
