using System.Collections;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private int collisionDamage = 5;
    [SerializeField] private int fallingRockDamage = 10;
    [SerializeField] private int collisionCooldown = 5;
    private bool _canApplyDamage = true;

    private AudioSource _collisionSound;
    private const float SoundOffset = 0.3f;

    private void Start()
    {
        _collisionSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("fallingRocks"))
        {
            PlayCollisionSound();
            submarineState.Health -= fallingRockDamage;
            return;
        }

        if (collision.transform.CompareTag("walls") && _canApplyDamage)
        {
            PlayCollisionSound();
            submarineState.Health -= collisionDamage;
            _canApplyDamage = false;
            StartCoroutine(CollisionCooldown());
        }
    }

    private void PlayCollisionSound()
    {
        _collisionSound.time = SoundOffset;
        _collisionSound.Play();
    }


    private IEnumerator CollisionCooldown()
    {
        yield return new WaitForSeconds(collisionCooldown);
        _canApplyDamage = true;
    }
}