using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

[System.Serializable]
public class Item
{
    public int index;
    public GameObject[] routeListsObj;
}
public class MoveController : MonoBehaviour
{  
    public Item RouteList;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
