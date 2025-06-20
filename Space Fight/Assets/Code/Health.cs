using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShakeOnDamageTaken;

    [Header("Health Effects")]
    [SerializeField] ParticleSystem hitEffect;
    CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    //On collision
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if other collider has a damage dealer script and define it
        DamageDealer damageDealer = otherCollider.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.Hit();
            playHitEffect();
            TakeDamage(damageDealer.GetDamage());
            shakeCamera();
        }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //If health runs out
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void playHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem explosion = Instantiate(hitEffect, transform.position, quaternion.identity);
            // Destroy after the duration of the particle effect + the lifetime of the partcile
            Destroy(explosion.gameObject, explosion.main.duration + explosion.main.startLifetime.constantMax);
        }
    }
    
    void shakeCamera()
    {
        if (cameraShake != null && applyCameraShakeOnDamageTaken)
        {
            cameraShake.Play();
        }
    }
}
