using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    float rechargeRate = 30;

    public static GameObject chargerBattery;
    public static bool charging;
    
    //Variables controlling power states
    public static bool canMove, canGun, canLight, canCharge;

    //Reference to other control scripts

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //print(chargerBattery);
        if (chargerBattery != null)
        {
            print("ischarging");
            if (chargerBattery.GetComponent<BatScript>().energy< chargerBattery.GetComponent<BatScript>().maxEnergy && charging)
            {
                print("ischarging");
                chargerBattery.GetComponent<BatScript>().energy += Time.deltaTime * rechargeRate;
            }
        }
/*        print("Move: "+ canMove);
        print("Gun: " + canGun);
        print("Light: " + canLight);
        print("Charge: " + canCharge);*/
    }
    public static void EnablePoweredState(string slotType,BatScript BatteryScript)
    {
        //Variables that control whether a control is powered or not
        switch (slotType)
        {
            case "Move":
                canMove = true;
                Debug.Log("Thruster Slot-in");
                PlayerPilotController.InsertPowerCell(BatteryScript);
                break;
            case "Gun":
                canGun = true;
                Debug.Log("Gun Slot-in");
                PlayerGunnerController.InsertPowerCell(BatteryScript);
                break;
            case "Light":
                canLight = true;
                break;
            case "Charge":
                canCharge = true;
                break;
        }
    }
    public static void DisablePoweredState(string slotType)
    {
        switch (slotType)
        {
            case "Move":
                canMove = false;
                PlayerPilotController.RemovePowerCell();
                break;
            case "Gun":
                canGun = false;
                PlayerGunnerController.RemovePowerCell();
                break;
            case "Light":
                canLight = false;
                break;
            case "Charge":
                canCharge = false;
                break;
        }
    }
    public void onCharge()
    {
        charging = true;
    }
    public void onChargeRelease()
    {
        charging = false;
    }
}
