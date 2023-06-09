using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class DebugMenuManager : MonoBehaviour
{
    public InputAction ToggleInfoInput;
    public GameObject DebugInfoRoot;
    private bool debugMenuEnabled;
    public PlayerSubController PlayerSubScript;
    public TextMeshProUGUI PositionText;
    public TextMeshProUGUI VelocityText;
    public TextMeshProUGUI TurretAngleText;
    public Slider HPGauge;
    // Start is called before the first frame update
    void Start()
    {
        debugMenuEnabled = DebugInfoRoot.activeSelf;
        HPGauge.maxValue=PlayerSubScript.Max_Sub_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(ToggleInfoInput.WasPressedThisFrame())
        {
            ToggleDebugInfo();
        }
        PositionText.text = PlayerSubScript.transform.position.ToString();
        VelocityText.text = PlayerSubScript.Actual_SubMoveForwardSpeed.ToString();
        TurretAngleText.text = PlayerSubScript.Turret_Root.transform.eulerAngles.ToString();
        HPGauge.value = PlayerSubScript.Sub_HP;
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
