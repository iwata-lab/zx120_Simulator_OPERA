using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLinkStopper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
    // オブジェクトのローカルPositionとローカルRotationを常に0に設定
    transform.localPosition = Vector3.zero;
    transform.localRotation = Quaternion.identity;
}
}
