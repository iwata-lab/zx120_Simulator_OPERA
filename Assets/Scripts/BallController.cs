using UnityEngine;

public class BallController : MonoBehaviour
{
    private float time = 0.0f;
    private int state = 1;

    private Rigidbody rb;

    public GameObject Point;  // 距離を測る対象のオブジェクト
    public float r = 5f;

    //public Color kinematicColor = Color.blue;   // isKinematic = true のときの色
    //public Color nonKinematicColor = Color.red; // isKinematic = false のときの色
    //private Renderer objectRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Point == null || rb == null)
        {
            return; // 必要なコンポーネントが欠けている場合は処理を中断
        }

        float distance = Vector3.Distance(transform.position, Point.transform.position);

        switch (state)
        {
            case 1: // 初期状態
                if (transform.position.y < 0.0f)
                {
                    state = 0;
                }
                break;

            case 0: // 地面に落ちた後
                time += Time.deltaTime;
                if (time >= 3.0f)
                {
                    SetKinematic(true);
                    state = 2;
                    time = 0.0f;
                }
                break;

            case 2: // キネマティック状態
                if (distance <= r)
                {
                    SetKinematic(false);
                    state = 3;
                }
                break;

            case 3: // ポイントに近づいた後
                if (distance > r)
                {
                    time += Time.deltaTime;
                    if (time >= 2.0f)
                    {
                        SetKinematic(true);
                        state = 2;
                        time = 0.0f;
                    }
                }
                break;
        }
    }

    private void SetKinematic(bool isKinematic)
    {
        if (rb != null)
        {
            rb.isKinematic = isKinematic;
            // UpdateColor();
        }
    }

    // private void UpdateColor()
    // {
    //     if (objectRenderer != null && rb != null)
    //     {
    //         objectRenderer.material.color = rb.isKinematic ? kinematicColor : nonKinematicColor;
    //     }
    // }
    
}