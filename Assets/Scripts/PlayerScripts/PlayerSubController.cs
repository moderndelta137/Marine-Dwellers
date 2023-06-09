using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubController : MonoBehaviour
{
    [Header("Common")]
    public bool CanMove; //Use to determine if the sub can move at all;
    public bool CanControl; // Use to determine if the player can control the movement of the sub;
    [Header("Pilot")]
    public float Defalut_SubMoveForwardSpeed;
    public float Actual_SubMoveForwardSpeed;
    public float Defalut_SubMoveSidewaySpeed;
    private float actual_SubMoveSidewaySpeed;
	[Header("Turret")]
    public GameObject Turret_Root;
    public float Defalut_TurretRotationSpeed;
    private float actual_TurretRotationSpeed;
    private float current_TurretAngle;
    public GameObject TurretCollider_Root;
    [Header("Collision")]
    private BoxCollider subCollider;
    public float Knockback_Distance;
    public float Knockback_Timer;
    [Header("Status")]
    public int Sub_HP;
    public int Max_Sub_HP;
    public int ObstacleDamage;
    public int EnemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        CanMove=true;
        CanControl=true;
        //Initialize
        Actual_SubMoveForwardSpeed=Defalut_SubMoveForwardSpeed;
        actual_SubMoveSidewaySpeed=Defalut_SubMoveSidewaySpeed;
        actual_TurretRotationSpeed=Defalut_TurretRotationSpeed;
        TurretCollider_Root.SetActive(false);
        subCollider = GetComponent<BoxCollider>();
        Sub_HP = Max_Sub_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            MoveSubForward();
        }
    }

    // Make the sub move forward every frame
    private void MoveSubForward()
    {
        this.gameObject.transform.Translate(Vector3.right*Actual_SubMoveForwardSpeed*Time.deltaTime,Space.Self);
    }

    // Steering the Sub up and down by calling this function from the PlayerPilotController Script.
    public void SteerSub(float InputAxisValue)
    {
        if(CanControl)
        {
            this.gameObject.transform.Translate(Vector3.up*InputAxisValue*actual_SubMoveSidewaySpeed*Time.deltaTime,Space.Self);
        }
    }

    // Rotate the turret clockwise or counter-clockwise by calling this function from the PlayerGunnerController Script.
    public void RotateTurret(float InputAxisValue)
    {
        if(CanControl)
        {
            Turret_Root.transform.Rotate(Vector3.forward*InputAxisValue*actual_TurretRotationSpeed*Time.deltaTime,Space.Self);
        }
    }

    // Turn the thruster on and off the make the sub move faster.
    public void TurnOnThruster()
    {
        Actual_SubMoveForwardSpeed = Defalut_SubMoveForwardSpeed * 2f;
    }

    public void TurnOffThruster()
    {
        Actual_SubMoveForwardSpeed = Defalut_SubMoveForwardSpeed;
    }

    // Turn the turret on and off when pressing and releasing the fire turret button.
    public void TurnOnTurret()
    {
        TurretCollider_Root.SetActive(true);
        Debug.Log("Turret Firing");
    }

    public void TurnOffTurret()
    {
        TurretCollider_Root.SetActive(false);
    }

    //Collision detection for hitting obstacles and enemies
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            //Knockback the sub for a distance when it gets hit.
            this.gameObject.transform.Translate(other.GetContact(0).normal*Knockback_Distance);
            //Reduce sub's hp
            ReduceSubHP(ObstacleDamage);
            //Disable the sub's movement for a short period of time
            StartCoroutine(DisableMovement());
        }
        else
        {
            this.gameObject.transform.Translate(other.GetContact(0).normal*Knockback_Distance);
        }
    }

    //Disable the sub's movement for a short period of time when get hit.
     IEnumerator DisableMovement()
     {
        CanMove=false;
        CanControl=false;
        yield return new WaitForSeconds(Knockback_Timer);
        CanMove=true;
        CanControl=true;
     }

     public void ReduceSubHP(int amount)
     {
        Sub_HP-=amount;
        if(Sub_HP<=0)
        {
            Destroy(this.gameObject);
            Debug.Log("Game Over");
        }
     }
}
