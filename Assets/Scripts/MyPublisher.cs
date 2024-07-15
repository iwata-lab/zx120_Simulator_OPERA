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

    private float boomUpperLimit = Mathf.Deg2Rad * 44.0f;
    private float boomLowerLimit = Mathf.Deg2Rad * -70.0f;
    private float armUpperLimit = Mathf.Deg2Rad * 152.0f;
    private float armLowerLimit = Mathf.Deg2Rad * 30.0f;
    private float bucketUpperLimit = Mathf.Deg2Rad * 143.0f;
    private float bucketLowerLimit = Mathf.Deg2Rad * -33f;

    private float boomDirection = 0.0f;
    private float swingDirection = 0.0f;
    private float armDirection = 0.0f;
    private float bucketDirection = 0.0f;
    private float leftWheel = 0.0f;
    private float rightWheel = 0.0f;
    private float translationVelocity = 2.5f;
    private float rotationVelocity = 2.0f;

    public string boomTopic = "zx120/boom/cmd";
    public string swingTopic = "zx120/swing/cmd";
    public string armTopic = "zx120/arm/cmd";
    public string bucketTopic = "zx120/bucket/cmd";
    public string tracksTopic = "zx120/tracks/cmd_vel";

    Float64Msg boomMsg = new Float64Msg() { data = -0.70f };
    Float64Msg swingMsg = new Float64Msg() { data = 0.0f };
    Float64Msg armMsg = new Float64Msg() { data = 1.57f };
    Float64Msg bucketMsg = new Float64Msg() { data = 0.79f };
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

        ros.Publish(boomTopic, boomMsg);
        ros.Publish(boomTopic, boomMsg);
        ros.Publish(swingTopic, swingMsg);
        ros.Publish(armTopic, armMsg);
    }

    void Update()
    {
        boomDirection = 0.0f;
        swingDirection = 0.0f;
        armDirection = 0.0f;
        bucketDirection = 0.0f;
        (leftWheel, rightWheel) = (0.0f, 0.0f);

        if (Input.GetKey("i") ^ Input.GetKey("k"))
        {
            if (Input.GetKey("i")) boomDirection = 1.0f;
            else if (Input.GetKey("k")) boomDirection = -1.0f;
        }

        if (Input.GetKey("d") ^ Input.GetKey("e"))
        {
            if (Input.GetKey("d")) swingDirection = 1.0f;
            else if (Input.GetKey("e")) swingDirection = -1.0f;
        }

        if (Input.GetKey("f") ^ Input.GetKey("s"))
        {
            if (Input.GetKey("f")) armDirection = 1.0f;
            else if (Input.GetKey("s")) armDirection = -1.0f;
        }


        if (Input.GetKey("j") ^ Input.GetKey("l"))
        {
            if (Input.GetKey("j")) bucketDirection = 1.0f;
            else if (Input.GetKey("l")) bucketDirection = -1.0f;
        }

        if (Input.GetKey("t") ^ Input.GetKey("g"))
        {
            if (Input.GetKey("t")) leftWheel = 1.0f;
            else if (Input.GetKey("g")) leftWheel = -1.0f;
        }

        if (Input.GetKey("y") ^ Input.GetKey("h"))
        {
            if (Input.GetKey("y")) rightWheel = 1.0f;
            else if (Input.GetKey("h")) rightWheel = -1.0f;
        }

        UpdateAndPublishMessages();

    }

    void UpdateAndPublishMessages()
    {
        if (boomDirection != 0)
        {
            boomMsg.data += boomDirection * boomIncreaseCoefficient * Time.deltaTime;
            boomMsg.data = (float)Mathf.Clamp((float)boomMsg.data, boomLowerLimit, boomUpperLimit);
            ros.Publish(boomTopic, boomMsg);
        }

        if (swingDirection != 0)
        {
            swingMsg.data += swingDirection * swingCoefficient * Time.deltaTime;
            ros.Publish(swingTopic, swingMsg);
        }

        if (armDirection != 0)
        {
            armMsg.data += armDirection * armIncreaseCoefficient * Time.deltaTime;
            armMsg.data = (float)Mathf.Clamp((float)armMsg.data, armLowerLimit, armUpperLimit);
            ros.Publish(armTopic, armMsg);
        }

        if (bucketDirection != 0)
        {
            bucketMsg.data += bucketDirection * bucketIncreaseCoefficient * Time.deltaTime;
            bucketMsg.data = (float)Mathf.Clamp((float)bucketMsg.data, bucketLowerLimit, bucketUpperLimit);
            ros.Publish(bucketTopic, bucketMsg);
        }


        tracksMsg.linear.x = translationVelocity * (leftWheel + rightWheel) / 2.0f;
        tracksMsg.angular.z = rotationVelocity * (rightWheel - leftWheel);
        ros.Publish(tracksTopic, tracksMsg);

    }
}
