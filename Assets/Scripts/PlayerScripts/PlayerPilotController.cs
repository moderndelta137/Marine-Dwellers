using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Needed to use the Input Action System

public class PlayerPilotController : MonoBehaviour
{
    public InputAction SteerSubInput; // Using the new Unity Input Action System.
    public static PlayerSubController SubControllerScript;
    private static bool isThrusterPowered;
    private static BatScript powerCell_Script;
    public float ThrusterPowerDrainRate;

    // Start is called before the first frame update
   
    void Awake()
    {
        SubControllerScript = GetComponent<PlayerSubController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SteerSubInput.ReadValue<float>()!=0)
        {
            //Call the PlayerSubController function to actually move the Sub up and down.
            SubControllerScript.SteerSub(SteerSubInput.ReadValue<float>());
        }

        if(isThrusterPowered)
        {
            powerCell_Script.DrainPower(ThrusterPowerDrainRate);
            if(powerCell_Script.energy<=0)
            {
                RemovePowerCell();
                SubControllerScript.TurnOffThruster();
            }
        }
    }

    public void OnEnable()
    {
        SteerSubInput.Enable();
    }

    public void OnDisable()
    {
        SteerSubInput.Disable();
    }

    public static void InsertPowerCell(BatScript inserted_PowerCell)
    {
        //called when powercell is inserted;
        isThrusterPowered=true;
        powerCell_Script = inserted_PowerCell;
        SubControllerScript.TurnOnThruster();

        //TODO: power up the sub function with the powercell.
    }
        public static void RemovePowerCell()
    {
        isThrusterPowered=false;
        powerCell_Script = null;
        SubControllerScript.TurnOffThruster();
    }
}
