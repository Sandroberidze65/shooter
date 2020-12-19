using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeThrow : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject grenadePrefab;

    int MaxGrenage = 5;
    int CurrentGrenade = -1;
    bool enter = true;


    void Start()
    {
        if (CurrentGrenade == -1)
        {
            CurrentGrenade = MaxGrenage;
        }

    }

    void OnGUI()
    {

        string count = " Grenade: " + CurrentGrenade;
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height - 100, 250, 30), count);
        }


    }

    void Update()
    {

        if (CurrentGrenade <= 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Throwexplode();
        }
    }

    void Throwexplode()
    {
        CurrentGrenade--;
        GameObject Grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = Grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
