using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    public void PlaySound(Collider other)
    {
        //obstacleタグが付いているオブジェクトと衝突した場合に音を鳴らす
        if (other.tag == "Obstacle")
        {
            audioSource.Play();
        }
    }
}