using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_change : MonoBehaviour
{
    [SerializeField] private GameObject head_button;
    [SerializeField] private Text comment;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(head_button.activeSelf)
        {
            comment.text = "試験開始前に頭部位置の登録を行います";
        }
        else
        {
            comment.text = "頭部位置の登録が完了しました\nスタートまでお待ちください";
        }

    }
}
