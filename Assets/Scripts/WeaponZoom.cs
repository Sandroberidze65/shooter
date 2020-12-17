using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV=60f;
    [SerializeField] float zoomedInFOV=20f;
    [SerializeField] float zoomedOutSencitivity=2f;
    [SerializeField] float zoomedInSencitivity=.5f;
    RigidbodyFirstPersonController fpsControler;

    private void Start() {
        fpsControler=GetComponent<RigidbodyFirstPersonController>();
    }
    bool zoomedInToggle=false;

    private void OnDisable() {
        ZoomOut();
    }
    
    private void Update(){
            if(Input.GetMouseButtonDown(1)){
                if(zoomedInToggle==false){
                ZoomIn();
                }else{
                ZoomOut();
            }
        
        }
    }

    private void ZoomIn(){
            zoomedInToggle=true;
            fpsCamera.fieldOfView=zoomedInFOV;
            fpsControler.mouseLook.XSensitivity=zoomedInSencitivity;
            fpsControler.mouseLook.YSensitivity=zoomedInSencitivity;
    }
    private void ZoomOut(){
            zoomedInToggle=false;
            fpsCamera.fieldOfView=zoomedOutFOV;
            fpsControler.mouseLook.XSensitivity=zoomedOutSencitivity;
            fpsControler.mouseLook.YSensitivity=zoomedOutSencitivity;
    }
    
}
