using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCamera2Controller : MonoBehaviour
{
    public float pan = 0;
    public float tilt = 60;
    public float dir = 10;

    GameObject zx120;
    Vector3 zx120Pos;


    float x;
    float y;
    float z;


    // Start is called before the first frame update
    void Start()
    {
        zx120 = GameObject.Find("zx120/base_link");
        zx120Pos = zx120.transform.position;

        float pan_rad = pan / 180 * Mathf.PI;
        float tilt_rad = tilt / 180 * Mathf.PI;

        x = -dir * Mathf.Sin(tilt_rad) * Mathf.Sin(pan_rad) + zx120Pos.x;
        y = dir * Mathf.Cos(tilt_rad) + zx120Pos.y;
        z = dir * Mathf.Sin(tilt_rad) * Mathf.Cos(pan_rad) + zx120Pos.z;

        this.transform.position = new Vector3(x, y, z);
        this.transform.LookAt(zx120.transform);
    }

    // Update is called once per frame
    void Update()
    {

        Transform myTransform = this.transform;
        zx120Pos = zx120.transform.position;

        float pan_rad = pan / 180 * Mathf.PI;
        float tilt_rad = tilt / 180 * Mathf.PI;

        x = -dir * Mathf.Sin(tilt_rad) * Mathf.Sin(pan_rad) + zx120Pos.x;
        y = dir * Mathf.Cos(tilt_rad) + zx120Pos.y;
        z = dir * Mathf.Sin(tilt_rad) * Mathf.Cos(pan_rad) + zx120Pos.z;

        this.transform.position = new Vector3(x, y, z);
        this.transform.LookAt(zx120.transform);
    }

}