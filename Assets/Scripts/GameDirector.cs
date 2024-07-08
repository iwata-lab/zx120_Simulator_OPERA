using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject mainCamera;
    GameObject subCamera1;
    GameObject subCamera2;
    GameObject subCamera3;

    GameObject getText;
    GameObject stackText;
    GameObject timerText;

    bool timerStop=true;

    int pointGet = 0;
    int pointStack = 0;

    float timer = 0;

    public void CountStackBall()
    {
        this.pointStack++;
    }

    public void CountGetBall()
    {
        this.pointGet++;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.Find("MainCamera");
        this.subCamera1 = GameObject.Find("zx120/base_link/body_link/SubCamera1");
        this.subCamera2 = GameObject.Find("zx120/base_link/body_link/SubCamera2");
        this.subCamera3 = GameObject.Find("SubCamera3");

        this.stackText = GameObject.Find("CountStackBall");
        this.getText = GameObject.Find("CountGetBall");
        this.timerText = GameObject.Find("CountTimer");

        /*        mainCamera.SetActive(true);
                subCamera1.SetActive(false);
                subCamera2.SetActive(false);
                subCamera3.SetActive(false);
        */
    }

    // Update is called once per frame
    void Update()
    {
        this.getText.GetComponent<Text>().text = this.pointGet.ToString() + " point";
        this.stackText.GetComponent<Text>().text = this.pointStack.ToString() + " point";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timerStop == true)
            {
                timerStop = false;
            }else if(timerStop == false){
                timerStop = true;
            }
            
        }

        if (timerStop == false)
        {
            timer += Time.deltaTime;
        }
        this.timerText.GetComponent<Text>().text = this.timer.ToString("N2") + " s";

        /*       if (Input.GetKeyDown(KeyCode.Space))
               {
                   switch (cameraSwitch)
                   {
                       case 0:
                           mainCamera.SetActive(false);
                           subCamera1.SetActive(true);
                           subCamera2.SetActive(false);
                           subCamera3.SetActive(false);
                           cameraSwitch++;
                           break;

                       case 1:
                           mainCamera.SetActive(false);
                           subCamera1.SetActive(false);
                           subCamera2.SetActive(true);
                           subCamera3.SetActive(false);
                           cameraSwitch++;
                           break;

                       case 2:
                           mainCamera.SetActive(false);
                           subCamera1.SetActive(false);
                           subCamera2.SetActive(false);
                           subCamera3.SetActive(true);
                           cameraSwitch++;
                           break;

                       case 3:
                           mainCamera.SetActive(true);
                           subCamera1.SetActive(false);
                           subCamera2.SetActive(false);
                           subCamera3.SetActive(false);
                           cameraSwitch = 0;
                           break;
                   }
               }*/

        if (Input.GetKeyDown(KeyCode.LeftArrow)) SceneManager.LoadScene("TrainingScene");
        
    }
}
