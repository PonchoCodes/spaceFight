using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [Header("Health Properties")]
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShakeOnDamageTaken;
    bool isPlayer = false;

    [Header("Health Effects")]
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int PointsToBeAddedOnDeath;

    //References to other scripts
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    UIDisplay uIDisplay;
    Animator animator;
    Volume volume;
    LoadDeathUI loadDeathUI;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        uIDisplay = FindFirstObjectByType<UIDisplay>();
        animator = gameObject.GetComponent<Animator>();
        volume = FindFirstObjectByType<Volume>();
        loadDeathUI = FindAnyObjectByType<LoadDeathUI>(FindObjectsInactive.Include);
        //Is our gameobject a player?
        if (gameObject.GetComponent<Player>() != null) { isPlayer = true; }
    }

    void Start()
    {
        UpdateHealthSlider();    
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
            UpdateHealthSlider();

        }
    }
    
    private void UpdateHealthSlider()
    {
        // Update health slider
        if (uIDisplay != null && isPlayer) { uIDisplay.UpdateHealthSlider(health); }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        //If health runs out
        if (health <= 0)
        {
            //If Enemy dies
            if (!isPlayer && scoreKeeper != null)
            {
                scoreKeeper.ModifyScore(PointsToBeAddedOnDeath);
            }
            
            //Load death UI
            if (loadDeathUI != null && isPlayer) { loadDeathUI.LoadTheDeathUI(); }
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
        if (animator != null && isPlayer)
        {
            animator.SetTrigger("gotHit");
        }
        if (volume != null && isPlayer)
        {
            StartCoroutine(ChromEffect());   
        }
    }

    IEnumerator ChromEffect()
    {
        volume.profile.TryGet(out ChromaticAberration chromAb);

        // Increase intensity
        while (chromAb.intensity.value < 1f)
        {
            chromAb.intensity.value += 0.5f * Time.deltaTime * 10;
            yield return new WaitForEndOfFrame();
        }

        chromAb.intensity.value = 1f;

        yield return new WaitForSeconds(0.5f);

        while (chromAb.intensity.value > 0f)
        {
            chromAb.intensity.value -= 0.5f * Time.deltaTime * 10;
            yield return new WaitForEndOfFrame();
        }

        // Ensure it ends exactly at 0
        chromAb.intensity.value = 0f;
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

    // Getters
    public float getHealth()
    {
        return health;
    }
}
