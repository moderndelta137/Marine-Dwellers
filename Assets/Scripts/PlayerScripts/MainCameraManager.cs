using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    public GameObject LockonTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A simple test script to make the camera follow the PlayerSub only on x axis
        this.transform.position=new Vector3( LockonTarget.transform.position.x,this.transform.position.y,this.transform.position.z);
    }
}
