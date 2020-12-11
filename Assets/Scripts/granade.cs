using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : MonoBehaviour
{
    public float delay=3f;
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
            Debug.Log("Hello");
            hasExploded=true;
            Explode();
            
        }

    }
    int i=0;

    void Explode(){
        
        Instantiate(explosionEffect,transform.position, transform.rotation);
        Debug.Log(i++);

        Destroy(gameObject);
        
    }
}
