using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider col;

    float originalHeight;
    public float reducedHeight;
    public float slideSpeed = 10f;

    bool isSliding;

    private void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        originalHeight = col.height;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    private void Sliding()
    {
        col.height = reducedHeight;
        rb.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }
    private void GoUp()
    {
        col.height = originalHeight;
    }
}
