using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_start : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;
    bool IsCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartCheck()
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString()};
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
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
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_start.csv", false, Encoding.UTF8);
        string[] s1 = { "time"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}