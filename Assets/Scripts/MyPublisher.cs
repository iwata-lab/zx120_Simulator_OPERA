using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;
using RosMessageTypes.Geometry;

public class MyPublisher : MonoBehaviour
{
    ROSConnection ros;
    private float boomIncreaseCoefficient = 0.271f;
    private float boomDecreaseCoefficient = 0.216f;
    private float swingCoefficient = 1.279f;
    private float armIncreaseCoefficient = 0.482f;
    private float armDecreaseCoefficient = 0.670f;
    private float bucketIncreaseCoefficient = 0.991f;
    private float bucketDecreaseCoefficient = 0.802f;

    private float leftWheel = 0.0f;
    private float rightWheel = 0.0f;
    private float translationVelocity = 1.714f;
    private float rotationVelocity = 1.0f;

    public string boomTopic = "zx120/boom/cmd";
    public string swingTopic = "zx120/swing/cmd";
    public string armTopic = "zx120/arm/cmd";
    public string bucketTopic = "zx120/bucket/cmd";
    public string tracksTopic = "zx120/tracks/cmd_vel";

    Float64Msg boomMsg = new Float64Msg() { data = -0.8f };
    Float64Msg swingMsg = new Float64Msg() { data = 0.0f };
    Float64Msg armMsg = new Float64Msg() { data = 2.0f };
    Float64Msg bucketMsg = new Float64Msg() { data = 0.8f };
    TwistMsg tracksMsg = new TwistMsg();

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<Float64Msg>(boomTopic);
        ros.RegisterPublisher<Float64Msg>(swingTopic);
        ros.RegisterPublisher<Float64Msg>(armTopic);
        ros.RegisterPublisher<Float64Msg>(bucketTopic);
        ros.RegisterPublisher<TwistMsg>(tracksTopic);
    }

    void Update()
    {
        (leftWheel, rightWheel) = (0.0f, 0.0f);
        if (Input.GetKey("i"))
        {
            boomMsg.data += boomIncreaseCoefficient * Time.deltaTime;
            ros.Publish(boomTopic, boomMsg);
        }

        if (Input.GetKey("k"))
        {
            boomMsg.data -= boomDecreaseCoefficient * Time.deltaTime;
            ros.Publish(boomTopic, boomMsg);
        }

        if (Input.GetKey("d"))
        {
            swingMsg.data += swingCoefficient * Time.deltaTime;
            ros.Publish(swingTopic, swingMsg);
        }

        if (Input.GetKey("e"))
        {
            swingMsg.data -= swingCoefficient * Time.deltaTime;
            ros.Publish(swingTopic, swingMsg);
        }

        if (Input.GetKey("f"))
        {
            armMsg.data += armIncreaseCoefficient * Time.deltaTime;
            ros.Publish(armTopic, armMsg);
        }

        if (Input.GetKey("s"))
        {
            armMsg.data -= armDecreaseCoefficient * Time.deltaTime;
            ros.Publish(armTopic, armMsg);
        }

        if (Input.GetKey("j"))
        {
            bucketMsg.data += bucketIncreaseCoefficient * Time.deltaTime;
            ros.Publish(bucketTopic, bucketMsg);
        }

        if (Input.GetKey("l"))
        {
            bucketMsg.data -= bucketDecreaseCoefficient * Time.deltaTime;
            ros.Publish(bucketTopic, bucketMsg);
        }

        if (Input.GetKey("t")) leftWheel=1.0f;
        if(Input.GetKey("g")) leftWheel=-1.0f;
        if(Input.GetKey("y")) rightWheel=1.0f;
        if(Input.GetKey("h")) rightWheel=-1.0f;

        tracksMsg.linear.x = translationVelocity * (leftWheel + rightWheel) / 2.0f;
        tracksMsg.angular.z = rotationVelocity * (rightWheel - leftWheel);
        ros.Publish(tracksTopic, tracksMsg);
    }
}
