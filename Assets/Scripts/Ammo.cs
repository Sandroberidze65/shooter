using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot{
        public AmmoType ammoType;
        public int ammoAmount;
    }


    public int GetAmmmo(AmmoType ammoType){
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public int DecreaseAmmo(AmmoType ammoType){
        return GetAmmoSlot(ammoType).ammoAmount--;
    }
    public int IncreaseAmmo(AmmoType ammoType, int ammoAmount){
        return GetAmmoSlot(ammoType).ammoAmount+=ammoAmount;
    }
    void OnGUI()
    {
        string count = " Bullets: " + GetAmmmo(0);
        GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height - 120, 250, 30), count);
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType){
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType==ammoType){
                return slot;
            }
        }
        return null;
    }


}
