using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    
    private float joystick1Vertical1;
    private float joystick1Vertical2;
    private float joystick2Horizontal;
    private float joystick2Vertical;
    private float joystick3Vertical;   // 新しく追加
    private float joystick3Horizontal; // 新しく追加

    private int fontSize;
    private int padding;
    private Rect backgroundRect;
    private GUIStyle labelStyle;
    private GUIStyle backgroundStyle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        fontSize = Mathf.Max(Screen.height / 40, 12);
        padding = fontSize / 2;

        InitializeStyles();

        int lineHeight = fontSize + padding;
        int totalHeight = 6 * lineHeight; // 6行に変更
        backgroundRect = new Rect(Screen.width - 260, Screen.height - totalHeight - padding, 260, totalHeight + padding * 2);
    }

    void InitializeStyles()
    {
        labelStyle = new GUIStyle();
        labelStyle.alignment = TextAnchor.MiddleRight;
        labelStyle.fontSize = fontSize;
        labelStyle.normal.textColor = Color.white;

        backgroundStyle = new GUIStyle();
        backgroundStyle.normal.background = MakeTexture(2, 2, new Color(0f, 0f, 0f, 0.5f));
    }

    Texture2D MakeTexture(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }

    void Update()
    {
        PlayerMove();
        PlayerTurn();
        PlayerMove2();
        PlayerTurn2();
        
        joystick1Vertical1 = Input.GetAxis("Joystick1Vertical1");
        joystick1Vertical2 = Input.GetAxis("Joystick1Vertical2");
        joystick2Horizontal = Input.GetAxis("Joystick2Horizontal");
        joystick2Vertical = Input.GetAxis("Joystick2Vertical");
        joystick3Vertical = Input.GetAxis("Joystick3Vertical");     // 新しく追加
        joystick3Horizontal = Input.GetAxis("Joystick3Horizontal"); // 新しく追加
    }

    // 前進・後退のメソッド
    void PlayerMove()
    {
        // 左スティックで操作
        movementInputValue = Input.GetAxis("Joystick1Vertical1");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // 旋回のメソッド
    void PlayerTurn()
    {
        // 右スティックで操作
        turnInputValue = Input.GetAxis("Joystick1Vertical1");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void PlayerMove2()
    {
        // 左スティックで操作
        movementInputValue = Input.GetAxis("Joystick2Horizontal");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime * 10;
        rb.MovePosition(rb.position + movement);
    }

    void PlayerTurn2()
    {
        // 右スティックで操作
        turnInputValue = Input.GetAxis("Joystick2Vertical");
        float turn = turnInputValue * turnSpeed * Time.deltaTime * 10;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    void OnGUI()
    {
        GUI.Box(backgroundRect, "", backgroundStyle);

        int lineHeight = fontSize + padding;

        string[] labels = new string[]
        {
            $"Joystick1Vertical1: {joystick1Vertical1:F2}",
            $"Joystick1Vertical2: {joystick1Vertical2:F2}",
            $"Joystick2Horizontal: {joystick2Horizontal:F2}",
            $"Joystick2Vertical: {joystick2Vertical:F2}",
            $"Joystick3Vertical: {joystick3Vertical:F2}",     
            $"Joystick3Horizontal: {joystick3Horizontal:F2}"  
        };

        for (int i = 0; i < labels.Length; i++)
        {
            Rect rect = new Rect(
                backgroundRect.x + padding, 
                backgroundRect.y + padding + (i * lineHeight), 
                backgroundRect.width - padding * 2, 
                lineHeight
            );
            GUI.Label(rect, labels[i], labelStyle);
        }
    }

}