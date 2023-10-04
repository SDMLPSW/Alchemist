using RosSharp.RosBridgeClient;
using RosSharp.RosBridgeClient.MessageTypes.Sensor;
using System;
using UnityEngine;

public class Joint_State_Publisher : MonoBehaviour
{
    private RosSocket rosSocket;
    public string topicName = "/joint_states_unity";
    public game4automation.Drive[] Axis;

    private int publishFrequency = 10;
    private float publishMessageTimer;

    private JointState jointStateMessage;

    public void Start()
    {
        rosSocket = GetComponent<RosConnector>().RosSocket;
        jointStateMessage = new JointState();
        rosSocket.Advertise<JointState>(topicName);

        // Initialize JointState message fields as per your requirements
        jointStateMessage.name = new string[] { "joint_1_s", "joint_2_l", "joint_3_u", "joint_4_r", "joint_5_b", "joint_6_t", "endmill"};
        jointStateMessage.position = new double[7];
        jointStateMessage.velocity = new double[] { };
        jointStateMessage.effort = new double[] { }; //{ 3087, 3087, 926.1, 88.2, 70.56, 50.31 };

        publishMessageTimer = Time.realtimeSinceStartup;
    }

    public void Update()
    {
        // Modify jointStateMessage fields based on your application
        // For example, let's just cycle the joint angles

        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        double currentUnixTimestampSeconds = (System.DateTime.UtcNow - epochStart).TotalSeconds;

        jointStateMessage.header.stamp.secs = (uint)currentUnixTimestampSeconds;
        jointStateMessage.header.stamp.nsecs = (uint)((currentUnixTimestampSeconds - Math.Floor(currentUnixTimestampSeconds)) * 1e9);


        for (int i = 0; i < 6; i++)
        {   
            if(i == 2 || i == 3 || i == 4)
            {
                jointStateMessage.position[i] = Axis[i].CurrentPosition * -1 * 3.141592 / 180;
                //jointStateMessage.velocity[i] = Axis[i].CurrentSpeed * -1;
            }
            else
            {
                jointStateMessage.position[i] = Axis[i].CurrentPosition * 3.141592 / 180;
                //jointStateMessage.velocity[i] = Axis[i].CurrentSpeed;
            }

        }

        //Debug.Log("Axis : " + Axis[0].CurrentPosition + " " + Axis[1].CurrentPosition + " " + Axis[2].CurrentPosition + " " + Axis[3].CurrentPosition + " " + Axis[4].CurrentPosition + " " + Axis[5].CurrentPosition );

        //jointStateMessage.position[6] = 0;
        //jointStateMessage.velocity[6] = 0;

        if (Time.realtimeSinceStartup > publishMessageTimer)
        {
            // Publish the message
            rosSocket.Publish(topicName, jointStateMessage);

            publishMessageTimer = Time.realtimeSinceStartup + 1.0f / publishFrequency;
        }
    }
}
