using UnityEngine;

public class BallBucketCollision : MonoBehaviour
{
    [SerializeField]
    private AudioSource _sound;

    void OnCollisionEnter()
    {
        _sound.Play();
    }
}
