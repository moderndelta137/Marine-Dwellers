using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BatScript : MonoBehaviour
{
    [SerializeField] Slider energyDisplay;

    GameObject connectedCell;

    bool grabbed = false;
    bool connected = false;

    float drainMultiplier = 10f;
    public float maxEnergy = 100;
    public float energy;

    // Start is called before the first frame update
    void Start()
    {
        energy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        energyDisplay.value = energy / maxEnergy;
        if (grabbed)
        {
            transform.position = Mouse.current.position.ReadValue();
        }
        if (connected && !string.Equals(connectedCell.GetComponent<CellSlotScript>().slotType, "Charge"))
        {
            //energy -= Time.deltaTime*drainMultiplier;
            if (energy <= 0)
            {
                PowerManager.DisablePoweredState(connectedCell.GetComponent<CellSlotScript>().slotType);
                energy = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slot")
        {
            connectedCell = collision.gameObject;
            PowerManager.EnablePoweredState(connectedCell.GetComponent<CellSlotScript>().slotType,this);
            grabbed = false;
            connected = true;
        }
    }
    public void OnGrab()
    {
        if (connectedCell != null)
        {
            if (connectedCell.GetComponent<CellSlotScript>().slotType == "Charge")
            {
                print("break");
                PowerManager.chargerBattery = null;
            }
            connectedCell.GetComponent<CellSlotScript>().batteryConnected = false;
            connectedCell.GetComponent<CellSlotScript>().connectedBattery = null;
            PowerManager.DisablePoweredState(connectedCell.GetComponent<CellSlotScript>().slotType);
        }
        connectedCell = null;
        connected = false;
        grabbed = true;
    }
    public void OnRelease()
    {
        grabbed = false;
    }

    //Allow other script to set the drain rate for different slot.
    public void DrainPower(float drainRate)
    {
        energy -= drainRate;
    }
}
