using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csv_collision : MonoBehaviour
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
        if (IsCheck)
        {
            timeNow = Time.realtimeSinceStartup - timeStart;
            collision_check script;
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach(GameObject obj in obstacles)
            {
                if (obj.GetComponent<collision_check>())
                {
                    script = obj.GetComponent<collision_check>();
                    string name = script.collision_name;
                    string pair_tag = script.collision_pair;
                    if (name != "")
                    {
                        if (pair_tag == "Target")
                        {
                            string[] s1 = {timeNow.ToString(), name, "Target"};
                            string s2 = string.Join(",", s1);
                            sw.WriteLine(s2);
                        }
                        else
                        {
                            string[] s1 = {timeNow.ToString(), name, "Kenki"};
                            string s2 = string.Join(",", s1);
                            sw.WriteLine(s2);
                        }

                        script.collision_name = "";
                    }
                }
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
        sw = new StreamWriter(@"Assets/ExperimentData/"+filename.text+"_collision.csv", false, Encoding.UTF8);
        string[] s1 = { "time", "object", "is_target"};
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        IsCheck = true;
    }
}