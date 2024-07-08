using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_check : MonoBehaviour
{
    GameObject csv_writer;
    bool check;
    bool sw;
    // Start is called before the first frame update
    void Start()
    {
        csv_writer = GameObject.Find("CSV writer");
        check = false;
        sw = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(check && sw)
        {
            csv_writer.GetComponent<csv_start>().StartCheck();
            sw = false;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Obstacle" && collision.gameObject.tag != "Ball" && collision.gameObject.tag != "Stone")
        {
            check = true;
        }
    }
}
