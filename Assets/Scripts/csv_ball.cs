using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_ball : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;

    int pickball;
    int getball;
    bool check;
    bool IsCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        timeStart = Time.realtimeSinceStartup;
        pickball = 0;
        getball = 0;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            if(check)
            {
                string[] s1 = {timeNow.ToString(), pickball.ToString(), getball.ToString()};
                string s2 = string.Join(",", s1);
                sw.WriteLine(s2);
                check = false;
            }
        }

    }
    public void CountPickBall()
    {
        pickball++;
        check = true;
    }
    public void CountGetBall()
    {
        getball++;
        check = true;
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
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_ball_count.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "pick", "get"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}