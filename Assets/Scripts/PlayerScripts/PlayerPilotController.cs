using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Needed to use the Input Action System

public class PlayerPilotController : MonoBehaviour
{
    public InputAction SteerSubInput; // Using the new Unity Input Action System.
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
        if (SteerSubInput.ReadValue<float>()!=0)
        {
            //Call the PlayerSubController function to actually move the Sub up and down.
            SubControllerScript.SteerSub(SteerSubInput.ReadValue<float>());
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
}
