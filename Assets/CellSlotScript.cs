using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSlotScript : MonoBehaviour
{
    [SerializeField] public string slotType;
    public bool batteryConnected = false;
    public GameObject connectedBattery;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bat" && batteryConnected==false)
        {
            connectedBattery = collision.gameObject;
            batteryConnected = true;
            if(string.Equals(slotType, "Charge"))
            {
                PowerManager.chargerBattery = connectedBattery;
            }
        }
    }
}
