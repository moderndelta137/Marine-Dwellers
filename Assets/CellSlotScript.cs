using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSlotScript : MonoBehaviour
{
    [SerializeField] string slotType;
    bool batteryConnected = false;
    GameObject connectedBattery;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(connectedBattery);
        if(connectedBattery!= null && connectedBattery.GetComponent<BatScript>().energy > 0)
        {
            print("Powered!");
        }
        else
        {
            print("Unpowered!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ye");
        if (collision.gameObject.tag == "Bat" && batteryConnected==false)
        {
            connectedBattery = collision.gameObject;
            batteryConnected = true;
        }
    }
}
