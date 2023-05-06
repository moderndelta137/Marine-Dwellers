using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField] GameObject movePhys, gunPhys, flashPhys, chargePhys;
    [SerializeField] SlotObj moveSlot, gunSlot, flashSlot, chargeSlot;

    List<SlotObj> slotArray = new List<SlotObj>();
    
    // Start is called before the first frame update
    void Start()
    {
        moveSlot = new SlotObj(movePhys, "move");
        gunSlot = new SlotObj(gunPhys, "move");
        flashSlot = new SlotObj(movePhys, "flash");
        chargeSlot = new SlotObj(chargePhys, "charge");

        slotArray = new List<SlotObj>() { moveSlot, gunSlot, flashSlot, chargeSlot };
    }

    // Update is called once per frame
    void Update()
    {

    }
}
public class SlotObj : MonoBehaviour
{
    string slotType;
    bool powered;
    float drainRate;
    public SlotObj(GameObject obj, string nSlotType="move", float nDrainRate=1f, bool nPowered = false)
    {
        slotType = nSlotType;
        powered = nPowered;
        drainRate = nDrainRate;
    }
}
