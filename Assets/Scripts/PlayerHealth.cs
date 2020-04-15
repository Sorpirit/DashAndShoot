
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private LayerMask damageLayers;
    [SerializeField] private float health; 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((damageLayers & (1 << other.gameObject.layer)) > 0)
        {
            GetDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if ((damageLayers & (1 << other.gameObject.layer)) > 0)
        {
            GetDamage();
        }
    }

    private void GetDamage()
    {
        health--;
        if(health <= 0)
            Destroy(gameObject);
    }
}
