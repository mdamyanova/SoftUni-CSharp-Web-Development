using UnityEngine;
using System.Collections;

public class WheelJointScript : MonoBehaviour 
{
    WheelJoint2D wheelJoint;
    JointMotor2D jointMotor;
	// Use this for initialization
	void Start () 
    {
        wheelJoint = GetComponent<WheelJoint2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jointMotor = wheelJoint.motor;
            jointMotor.motorSpeed += 1f;
            wheelJoint.motor = jointMotor;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jointMotor = wheelJoint.motor;
            jointMotor.motorSpeed -= 1f;
            wheelJoint.motor = jointMotor;
        }
	}
}
