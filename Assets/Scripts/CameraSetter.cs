using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    public float pan = 45;
    public float tilt = 45;
    public float dir = 10;

    GameObject centerPoint;
    Vector3 poolPos;


    float x;
    float y;
    float z;


    // Start is called before the first frame update
    void Start()
    {
        centerPoint = GameObject.Find("zx120/base_link/body_link/CenterPoint");
        poolPos = centerPoint.transform.position;

        float pan_rad = pan / 180 * Mathf.PI;
        float tilt_rad = tilt / 180 * Mathf.PI;

        x = -dir * Mathf.Sin(tilt_rad) * Mathf.Sin(pan_rad) + poolPos.x;
        y = dir * Mathf.Cos(tilt_rad) + poolPos.y;
        z = dir * Mathf.Sin(tilt_rad) * Mathf.Cos(pan_rad) + poolPos.z;

        this.transform.position = new Vector3(x, y, z);
        this.transform.LookAt(centerPoint.transform);
    }

    // Update is called once per frame
    void Update()
    {

 /*       Transform myTransform = this.transform;
        poolPos = centerPoint.transform.position;

        float pan_rad = pan / 180 * Mathf.PI;
        float tilt_rad = tilt / 180 * Mathf.PI;

        x = -dir * Mathf.Sin(tilt_rad) * Mathf.Sin(pan_rad) + poolPos.x;
        y = dir * Mathf.Cos(tilt_rad) + poolPos.y;
        z = dir * Mathf.Sin(tilt_rad) * Mathf.Cos(pan_rad) + poolPos.z;

        this.transform.position = new Vector3(x, y, z);
        this.transform.LookAt(centerPoint.transform);
 */
    }

}
