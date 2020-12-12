using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health=100f;



    public void TakeDamage(float damage){
        
        if(health<=0 || health<damage){
            GetComponent<DeathHandler>().HandleDeath();
        }
        else{
            Debug.Log("bang bang");
            health-=damage;
        }
    }

}
