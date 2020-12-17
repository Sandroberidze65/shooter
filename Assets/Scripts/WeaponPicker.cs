using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    public Weapon weaponScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, Weapons, MainCamera;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start() {
        if(!equipped){
            
            weaponScript.enabled = false;
            rb.isKinematic=false;
            coll.isTrigger=false;
        }
        if(equipped){
            
            weaponScript.enabled = true;
            rb.isKinematic=true;
            coll.isTrigger=true;
            slotFull=true;
        }
    }

    private void Update(){
        Vector3 distanceToPlayer=player.position-transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKey(KeyCode.E) && !slotFull){
             Debug.Log("picked");
            PickUp();
        }
        if(equipped && Input.GetKeyDown(KeyCode.Q)){
             Debug.Log("Droped");
            Drop();
        }
    }

    private void PickUp(){
        equipped=true;
        slotFull=true;

        transform.SetParent(Weapons);
        transform.localPosition=Vector3.zero;
        transform.localRotation=Quaternion.Euler(Vector3.zero);
        transform.localScale= Vector3.one;

        rb.isKinematic=true;
        coll.isTrigger=true;

        weaponScript.enabled = true;
    }
    private void Drop(){
        equipped=false;
        slotFull=false;
        transform.SetParent(null);
        rb.isKinematic=false;
        coll.isTrigger=false;
        rb.velocity=player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(MainCamera.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(MainCamera.up * dropUpwardForce, ForceMode.Impulse);

        float random=Random.Range(-1f,1f);
        rb.AddTorque(new Vector3(random,random,random)* 10);

        weaponScript.enabled = false;
    }


}
