using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_target_pos_2 : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;
    [SerializeField] private Transform target;
    private Vector3 pos_pre;
    bool IsCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
        pos_pre = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            if(target.position != pos_pre)
            {
                string[] s1 = {timeNow.ToString(), target.position.x.ToString(), target.position.y.ToString(), target.position.z.ToString()};
                string s2 = string.Join(",", s1);
                sw.WriteLine(s2);
                pos_pre = target.position;
            }
        }

    }
    
    private void OnApplicationQuit()
    {
        if (IsCheck)
        {
            sw.Close();
        }
    }

    public void MakeFile(Text filename)
    {
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_target_pos_2.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "pos_x", "pos_y", "pos_z"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}