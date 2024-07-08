using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_check : MonoBehaviour
{
    public string collision_name = "";
    public string collision_pair = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Obstacle" && collision.gameObject.tag != "Ball" && collision.gameObject.tag != "Stone")
        {
            collision_name = gameObject.name;
            collision_pair = collision.gameObject.tag;
        }
    }
}
