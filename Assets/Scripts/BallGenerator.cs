using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [Header("Ball Settings")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int ballCount = 2000;
    [SerializeField] private float ballRadius = 0.05f;

    [Header("Generation Area")]
    [SerializeField] private float areaDepth = 5f;
    [SerializeField] private float areaWidth = 3f;
    [SerializeField] private float areaHeight = 4f;
    [SerializeField] private Vector3 areaCenter = new Vector3(0f, 2f, -9.75f);

    private float time = 0.0f;

    private void Start()
    {
        GenerateBalls();
    }

    private void Update()
    {
        if (time >= 0.0f) time += Time.deltaTime;
        if (time > 6.0f)
        {
            GenerateBalls();
            time = -1.0f;
        }
    }

    private void GenerateBalls()
    {
        for (int i = 0; i < ballCount; i++)
        {
            Vector3 position = CalculateRandomPosition();
            InstantiateBall(position);
        }
        Debug.Log($"Generated {ballCount} balls");
    }

    private Vector3 CalculateRandomPosition()
    {
        float x = Random.Range(-areaWidth / 2f + ballRadius, areaWidth / 2f - ballRadius);
        float y = Random.Range(ballRadius, areaHeight - ballRadius);
        float z = Random.Range(-areaDepth / 2f + ballRadius, areaDepth / 2f - ballRadius);

        return new Vector3(x, y, z) + areaCenter;
    }

    private void InstantiateBall(Vector3 position)
    {
        Instantiate(ballPrefab, position, Quaternion.identity, transform);
    }
}