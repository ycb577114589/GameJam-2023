using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    private Camera _camera;
    private List<GameObject> _selectedObjects;
    
    public List<GameObject> SelectObjects()
    {
        return _selectedObjects;
    }

    private void Start()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
        Ray ray;
        RaycastHit hitObj;
        _selectedObjects = new List<GameObject>();
        if (Input.GetMouseButton(0))
        {
            ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitObj, 200, 8))
            {
                if (hitObj.collider.gameObject != null)
                {
                    _selectedObjects.Add(hitObj.collider.gameObject);
                }
            }
        }
        foreach (var touch in Input.touches)
        {
            ray = _camera.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hitObj, 200, 8))
            {
                if (hitObj.collider.gameObject != null)
                {
                    _selectedObjects.Add(hitObj.collider.gameObject);
                }
            }
        }
    }
}
