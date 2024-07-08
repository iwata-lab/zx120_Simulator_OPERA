using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCameraController : MonoBehaviour
{
    public GameObject centerPoint;
    public float r = 6;
    public float theta = 60;
    public float phi = -135;

    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        x = -r * Mathf.Sin(theta / 180 * Mathf.PI) * Mathf.Sin(phi / 180 * Mathf.PI);
        y = r * Mathf.Cos(theta / 180 * Mathf.PI);
        z = r * Mathf.Sin(theta / 180 * Mathf.PI) * Mathf.Cos(phi / 180 * Mathf.PI);
        transform.localPosition = new Vector3(x, y, z);
        transform.LookAt(centerPoint.transform);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
