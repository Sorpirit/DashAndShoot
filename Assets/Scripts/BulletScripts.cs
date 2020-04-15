using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletScripts : MonoBehaviour
{
    [SerializeField] private float rekoshetChance;
    [SerializeField] private Rigidbody2D myRigidBody;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Random.Range(0, 1f) <= rekoshetChance)
        {
            ContactPoint2D[] pint = new ContactPoint2D[1];
            other.GetContacts(pint);

            Vector2 dir = (pint[0].point -(Vector2) transform.position).normalized * 2;
            dir += Random.insideUnitCircle;
            dir.Normalize();

            myRigidBody.velocity = dir * myRigidBody.velocity.magnitude;
        }else
            Destroy(gameObject);
    }
}
