using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnablePoweredState(string slotType)
    {
        switch (slotType)
        {
            case "Move":
                break;
            case "Gun":
                break;
            case "Light":
                break;
            case "Charge":
                break;
        }
    }
    public void DisablePoweredState(string slotType)
    {
        switch (slotType)
        {
            case "Move":
                break;
            case "Gun":
                break;
            case "Light":
                break;
            case "Charge":
                break;
        }
    }
}
