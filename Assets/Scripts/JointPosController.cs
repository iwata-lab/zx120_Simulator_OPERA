using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class JointPosController : MonoBehaviour
{
    private ROSConnection ros;
    public string setpointTopicName = "joint_name/setpoint";
    public double initTargetPos;
    private ArticulationBody joint;
    private Float64Msg targetPos;

    public int stiffness = 200000;
    public int damping = 100000;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        joint = this.GetComponent<ArticulationBody>();
        targetPos = new Float64Msg();

        if (joint)
        {
            var drive = joint.xDrive;
            if (drive.stiffness == 0)
                drive.stiffness = stiffness;
            if (drive.damping == 0)
                drive.damping = damping;
            if (drive.forceLimit == 0)
                drive.forceLimit = 100000;
            targetPos.data = initTargetPos;
            drive.target = (float)(targetPos.data * Mathf.Rad2Deg);
            joint.xDrive = drive;
            Debug.Log("drive : "+drive.target);
        }
        else
        {
            Debug.Log("No ArticulationBody are found");
        }

        ros.Subscribe<Float64Msg>(setpointTopicName, ExecuteJointPosControl);
    }

    void ExecuteJointPosControl(Float64Msg msg)
    {
        targetPos = msg;
        var drive = joint.xDrive;
        drive.target = (float)(targetPos.data * Mathf.Rad2Deg);
        joint.xDrive = drive;
        //Debug.Log("Joint Target Position:" + targetPos.data);
    }
}
