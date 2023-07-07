using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.LogError("test1");
    }

    // Update is called once per frame
    void Update()
    {
        
        UnityEngine.Debug.LogError("test2");
    }
}
