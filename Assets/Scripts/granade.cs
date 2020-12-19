﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : MonoBehaviour
{
    public float delay=3f;
    public float radius = 5f;
    public float force = 700f;

    bool hasExploded=false;

    public GameObject explosionEffect;

    float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown=delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded){
            hasExploded=true;
            Explode();
            
        }

    }
    int i=0;

    void Explode(){
        
        Instantiate(explosionEffect,transform.position, transform.rotation);
        Collider[] colliders= Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
        
    }
}
