using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacing : MonoBehaviour
{
    private Camera cam;
    
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (mousePos - (Vector2) transform.position).normalized;
    }
}
