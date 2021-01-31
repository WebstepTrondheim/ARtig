using UnityEngine;

public class BallBucketCollision : MonoBehaviour
{
    [SerializeField]
    private AudioSource _sound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
            _sound.PlayOneShot(_sound.clip);
    }
}
