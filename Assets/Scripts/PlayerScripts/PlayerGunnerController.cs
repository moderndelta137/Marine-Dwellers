using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Needed to use the Input Action System

public class PlayerGunnerController : MonoBehaviour
{
    public InputAction RotateTurretInput; // Using the new Unity Input Action System.
    public PlayerSubController SubControllerScript;
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
        if (RotateTurretInput.ReadValue<float>()!=0)
        {
            //Call the PlayerSubController function to actually move the Sub up and down.
            SubControllerScript.RotateTurrent(RotateTurretInput.ReadValue<float>());
        }
    }
    public void OnEnable()
    {
        RotateTurretInput.Enable();
    }

    public void OnDisable()
    {
        RotateTurretInput.Disable();
    }
}
