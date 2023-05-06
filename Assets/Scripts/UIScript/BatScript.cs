using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BatScript : MonoBehaviour
{
    [SerializeField] Slider energyDisplay;

    bool grabbed = false;
    bool connected = false;

    float drainMultiplier = 10f;
    float maxEnergy = 100;
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
        if (connected)
        {
            energy -= Time.deltaTime*drainMultiplier;
            if (energy <= 0)
            {
                energy = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slot")
        {
            grabbed = false;
            connected = true;
        }
    }
    public void OnGrab()
    {
        connected = false;
        grabbed = true;
    }
    public void OnRelease()
    {
        grabbed = false;
    }
}
