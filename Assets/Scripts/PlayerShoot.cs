using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fierRate;
    [SerializeField] private Transform fierPoint;
    [SerializeField] private float bulletSpeed;
    

    private float fierTimer;
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && fierTimer >= fierRate)
        {
            Fier();
            fierTimer = 0;
        }

        fierTimer += Time.deltaTime;
    }

    private void Fier()
    {
        GameObject projecttile = Instantiate(bullet, fierPoint.position, fierPoint.rotation);
        projecttile.transform.up = fierPoint.up;
        if (projecttile.TryGetComponent(out Rigidbody2D bulletRb))
        {
            bulletRb.velocity = fierPoint.up * bulletSpeed;
        }
    }
}
