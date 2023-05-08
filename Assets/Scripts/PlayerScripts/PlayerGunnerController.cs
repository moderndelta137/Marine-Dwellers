using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Needed to use the Input Action System

public class PlayerGunnerController : MonoBehaviour
{
    public InputAction RotateTurretInput; // Using the new Unity Input Action System.
    public InputAction FireTurretInput;
    public PlayerSubController SubControllerScript;
    private static BatScript powerCell_Script;
    public static bool TurretPowered;
    public float TurretPowerDrainRate;


    // Start is called before the first frame update
    void Awake()
    {
        SubControllerScript = GetComponent<PlayerSubController>();
    }
    void Start()
    {
        TurretPowered=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateTurretInput.ReadValue<float>()!=0)
        {
            //Call the PlayerSubController function to actually move the Sub up and down.
            SubControllerScript.RotateTurret(RotateTurretInput.ReadValue<float>());
        }

        //Fire Turrent
        if (FireTurretInput.IsPressed())
        {
            if(TurretPowered)
            {
                SubControllerScript.TurnOnTurret();
                powerCell_Script.DrainPower(TurretPowerDrainRate);
                if(powerCell_Script.energy<=0)
                {
                    RemovePowerCell();
                    SubControllerScript.TurnOffTurret();
                }
            }
        }
        else if(FireTurretInput.WasReleasedThisFrame())
        {
            SubControllerScript.TurnOffTurret();
        }
    }
    public void OnEnable()
    {
        RotateTurretInput.Enable();
        FireTurretInput.Enable();
    }

    public void OnDisable()
    {
        RotateTurretInput.Disable();
        FireTurretInput.Disable();
    }

    public static void InsertPowerCell(BatScript inserted_PowerCell)
    {
        TurretPowered=true;
        powerCell_Script = inserted_PowerCell;
    }
    public static void RemovePowerCell()
    {
        TurretPowered=false;
        powerCell_Script = null;
    }
}
