using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    public GameObject stonePrefab;
    public int n = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoroutine());
    }

    // ���̏d�Ȃ���`�F�b�N����֐�
    

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(1.0f);

        float x = 0;
        float y = 0;
        float z = 0;
        
        GameObject stone;
        var posxlist = new List<float>()
        {
            0.6f, -0.6f, -0.3f
        };
        var poszlist = new List<float>()
        {
            0.4f, 1.4f, -0.6f
        };

        for (int i = 0; i < n; i++)
        {
            stone = Instantiate(stonePrefab) as GameObject;

            x = posxlist[i];
            y = 5;
            z = poszlist[i];

            stone.transform.position = new Vector3(x, y, -10.7f+z);

            UnityEngine.Debug.Log("Ok");
        }
    }
}
