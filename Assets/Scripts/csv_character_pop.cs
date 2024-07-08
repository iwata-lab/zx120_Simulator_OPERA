using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_character_pop : MonoBehaviour
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

    public void LeftAnswerRecord(string area, string question, string c, string answer_state, string ans_time)
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), area, "left", question, c, answer_state, ans_time};
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }
    }
    public void RightAnswerRecord(string area, string question, string c, string answer_state, string ans_time)
    {
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            string[] s1 = {timeNow.ToString(), area, "right", question, c, answer_state, ans_time};
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
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_character_pop.csv", false, Encoding.UTF8);
        string[] s1 = { "Time", "Area", "LorR", "Question", "Character", "State", "Answer_Time"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}
