using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubController : MonoBehaviour
{
    public float Defalut_SubMoveForwardSpeed;
    private float actual_SubMoveForwardSpeed;
    public float Defalut_SubMoveSidewaySpeed;
    private float actual_SubMoveSidewaySpeed;
    public bool CanMove; //Use to determine if the sub can move at all;
    public bool CanControl; // Use to determine if the player can control the movement of the sub;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize
        actual_SubMoveForwardSpeed=Defalut_SubMoveForwardSpeed;
        actual_SubMoveSidewaySpeed=Defalut_SubMoveSidewaySpeed;
        CanMove=true;
        CanControl=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            MoveSubForward();
            if(CanControl)
            {
                this.gameObject.transform.Translate(Vector3.up*Input.GetAxis("Vertical")*actual_SubMoveSidewaySpeed*Time.deltaTime,Space.Self);
            }
        }
    }

    // Make the sub move forward every frame
    private void MoveSubForward()
    {
        this.gameObject.transform.Translate(Vector3.right*actual_SubMoveForwardSpeed*Time.deltaTime,Space.Self);
    }
}
