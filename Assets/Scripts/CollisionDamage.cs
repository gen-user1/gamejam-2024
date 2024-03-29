using System.Collections;
using ScriptableObjects;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] private SubmarineState submarineState;
    [SerializeField] private int collisionDamage = 5;
    [SerializeField] private int collisionCooldown = 5;
    private bool _canApplyDamage = true;


    void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("walls") || !_canApplyDamage)
        {
            return;
        }

        submarineState.Health -= collisionDamage;
        _canApplyDamage = false;
        StartCoroutine(CollisionCooldown());
    }


    IEnumerator CollisionCooldown()
    {
        yield return new WaitForSeconds(collisionCooldown);
        _canApplyDamage = true;
    }
}