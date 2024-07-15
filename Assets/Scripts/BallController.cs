using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float posX = 0;
    float posY = 0;
    float posZ = 0;
    float time = 1.0f;
    int n = 1;
    int m = 0;
    GameObject csv_writer;

    // Start is called before the first frame update
    void Start()
    {
        csv_writer = GameObject.Find("CSV writer");
    }



    // Update is called once per frame
    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        if (posY < 1.5f)
        {
            n = 0;
        }
        if (n==0 && 1.5f<posY)
        {
            n++;
            csv_writer.GetComponent<csv_ball>().CountPickBall();
        }

        if (2.75f<posX && posX<6.25 && 1.4f<posY && posY<2 && -5.5<posZ && posZ<-3.5)
        {
            if (m == 0)
            {
                this.time -= Time.deltaTime;
                if (time < 0)
                {
                    csv_writer.GetComponent<csv_ball>().CountGetBall();
                    m++;
                }
            }
        }
    }
}
