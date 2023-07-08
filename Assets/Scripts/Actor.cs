using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Actor : MonoBehaviour
{
    private static int gIdx = 0;

    private int myIdx;
    public int max_health;
    private int health;
    private bool isClicked;
    private double leftClickTime;

    private void Start()
    {
        health = max_health;
        myIdx = gIdx++;
    }

    private void Update()
    {
        bool checkClicked = false;
        foreach (var selectObj in InputSystem.Instance.SelectObjects())
        {
            if (this.gameObject == selectObj)
            {
                checkClicked = true;
            }
        }

        if (isClicked && !checkClicked)
        {
            isClicked = false;
        }else if (!isClicked && checkClicked)
        {
            leftClickTime = 0;
            isClicked = true;
        }

        if (isClicked)
        {
            leftClickTime += Time.deltaTime;
            if (leftClickTime > 0.1)
            {
                leftClickTime -= 0.1;
                health -= 3;
            }
        }
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(0, myIdx * 40, 250, 40), "is_clicked: " + isClicked + " health: " + health);
    }
}
