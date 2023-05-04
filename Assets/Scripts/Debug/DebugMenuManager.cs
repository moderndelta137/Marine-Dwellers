using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugMenuManager : MonoBehaviour
{
    public InputAction ToggleInfoInput;
    public GameObject DebugInfoRoot;
    private bool debugMenuEnabled;
    // Start is called before the first frame update
    void Start()
    {
        debugMenuEnabled = DebugInfoRoot.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        if(ToggleInfoInput.WasPressedThisFrame())
        {
            ToggleDebugInfo();
        }
    }

    public void OnEnable()
    {
        ToggleInfoInput.Enable();
    }

    public void OnDisable()
    {
        ToggleInfoInput.Disable();
    }

    public void ToggleDebugInfo()
    {
        debugMenuEnabled = !debugMenuEnabled;
        DebugInfoRoot.SetActive(debugMenuEnabled);
    }
}
