using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public int n = 2000;
    public float radius = 0.05f;
    public float depth = 5;
    public float width = 3;

    // Start is called before the first frame update
    void Start()
    {
        
        float x = 0;
        float y = 0;
        float z = 0;
        
        GameObject ball;

        for (int i = 0; i < n; i++)
        {
            ball = Instantiate(ballPrefab) as GameObject;

            // �K�؂Ȉʒu�Ɉړ����邽�߂ɁA���̔��a���l�����ă����_���Ȉʒu�𐶐�����
            x = Random.Range(-width/2.0f + radius, width / 2.0f - radius);
            y = Random.Range(radius, 4.0f);
            z = Random.Range(-depth/2.0f + radius, depth/2.0f - radius);

            

            // ����K�؂Ȉʒu�Ɉړ�����
            ball.transform.position = new Vector3(x, y, -9.75f+z);

            UnityEngine.Debug.Log("Ok");
        }
    }

    // ���̏d�Ȃ���`�F�b�N����֐�
    

    // Update is called once per frame
    void Update()
    {

    }
}
