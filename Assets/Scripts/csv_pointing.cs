using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_pointing : MonoBehaviour
{
    private StreamWriter sw;
    private float timeNow;
    private float timeStart;
    [SerializeField] private Transform nail;
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
    public void PosCheck()
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), nail.position.x.ToString(), nail.position.y.ToString(), nail.position.z.ToString()};
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
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_pointing.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "pos_x", "pos_y", "pos_z"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}