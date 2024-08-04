using UnityEngine;
using UnityEngine.UI;
using System; // Add this for Math functions

public class LeftJoystickControlledImage : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    public float maxMoveDistance = 100f;
    public float smoothTime = 0.1f; // 動きを滑らかにするための時間
    private Vector2 velocity = Vector2.zero;

    public string joystickHorizontalAxis;
    public string joystickVerticalAxis;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("This script must be attached to a UI Image!");
            return;
        }
        initialPosition = rectTransform.anchoredPosition;
        targetPosition = initialPosition;
    }

    void Update()
    {
        float armState = zx120Controller.armDirection;
        float swingState = zx120Controller.swingDirection;
        Vector2 offset;

        if (Math.Pow(armState, 2) + Math.Pow(swingState, 2) < 1)
        {
            offset = new Vector2(armState, -swingState) * maxMoveDistance;
        }
        else
        {
            offset = new Vector2(armState, -swingState) * maxMoveDistance / (float)Math.Sqrt(Math.Pow(armState, 2) + Math.Pow(swingState, 2));
        }

        targetPosition = initialPosition + offset;

        // Smoothly move the image
        rectTransform.anchoredPosition = Vector2.SmoothDamp(
            rectTransform.anchoredPosition, 
            targetPosition, 
            ref velocity, 
            smoothTime
        );
    }
}
