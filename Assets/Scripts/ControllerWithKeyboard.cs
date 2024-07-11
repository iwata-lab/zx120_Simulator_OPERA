using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.BuiltinInterfaces;
using RosMessageTypes.Std;
using RosMessageTypes.Sensor;
using Unity.Robotics.UrdfImporter;
using Unity.Robotics.Core;

public class ControllerWithKeyboard : MonoBehaviour
{
    // Start is called before the first frame update
    ROSConnection ros;
    public string topicName = "joint_states";
    private JointStateMsg message;
    private List<ArticulationBody> joints;
    private List<string> jointNames;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
