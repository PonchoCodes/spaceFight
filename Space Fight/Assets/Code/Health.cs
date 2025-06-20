using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShakeOnDamageTaken;
    bool isPlayer = false;

    [Header("Health Effects")]
    [SerializeField] ParticleSystem hitEffect;

    //References to other scripts
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = audioPlayer = FindFirstObjectByType<AudioPlayer>();
        //Is our gameobject a player?
        if (gameObject.GetComponent<Player>() != null) { isPlayer = true; }
    }

    //On collision
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if other collider has a damage dealer script and define it
        DamageDealer damageDealer = otherCollider.GetComponent<DamageDealer>();
        if (damageDealer != null) // When taking damage
        {
            damageDealer.Hit();
            playHitEffect();
            TakeDamage(damageDealer.GetDamage());
            shakeCamera();
            playHitSFX();

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
    
    void playHitSFX()
    {
        if (audioPlayer != null)
        {
            if (isPlayer) { audioPlayer.PlayDamageTakenPlayer(); }
            else { audioPlayer.PlayDamageTakenEnemy(); }
        }
    }
}
