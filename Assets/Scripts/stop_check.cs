using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop_check : MonoBehaviour
{
    GameObject csv_writer;

    // Start is called before the first frame update
    void Start()
    {
        csv_writer = GameObject.Find("CSV writer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("aaaa" + collision.gameObject.tag);
        csv_writer.GetComponent<csv_pointing>().PosCheck();
    }
}
