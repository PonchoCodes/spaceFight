using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] float pitchVariance = 0.05f;
    [SerializeField] bool varyPitch = true;

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClipPlayer;
    [SerializeField] AudioClip shootingClipEnemy;
    [SerializeField] AudioClip shootingClipBigEnemy;
    //To note is the Range modifier which adds a set range in the inspector and a slider
    [SerializeField][Range(0f, 1f)] float shootingVolumePlayer = 1f;
    [SerializeField][Range(0f, 1f)] float shootingVolumeEnemy = 1f;
    [SerializeField][Range(0f, 1f)] float shootingVolumeBigEnemy = 1f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip damageClipPlayer;
    [SerializeField] AudioClip damageClipEnemy;
    [SerializeField] AudioClip damageClipBigEnemy;
    [SerializeField][Range(0f, 1f)] float damageVolumePlayer = 1f;
    [SerializeField][Range(0f, 1f)] float damageVolumeEnemy = 1f;
    [SerializeField][Range(0f, 1f)] float damageVolumeBigEnemy = 1f;

    [Header("Shatter Bullet")]
    [SerializeField] AudioClip BulletSplittingClip;
    [SerializeField][Range(0f, 1f)] float BulletSplittingVolume = 1f;

    // Player Shooting
    public void PlayShootingClipPlayer()
    {
        if (shootingClipPlayer != null)
        {
            audioSource.PlayOneShot(shootingClipPlayer, shootingVolumePlayer);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
    //Enemy Shooting
    public void PlayShootingClipEnemy()
    {
        if (shootingClipEnemy != null)
        {
            audioSource.PlayOneShot(shootingClipEnemy, shootingVolumeEnemy);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
    //Big Enemy Shooting
    public void PlayShootingClipBigEnemy()
    {
        if (shootingClipBigEnemy != null)
        {
            audioSource.PlayOneShot(shootingClipBigEnemy, shootingVolumeBigEnemy);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }

    // Player damage taken
    public void PlayDamageTakenPlayer()
    {
        if (damageClipPlayer != null)
        {
            audioSource.PlayOneShot(damageClipPlayer, damageVolumePlayer);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
    //Enemy damage taken
    public void PlayDamageTakenEnemy()
    {
        if (damageClipEnemy != null)
        {
            audioSource.PlayOneShot(damageClipEnemy, damageVolumeEnemy);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }

    //Big Enemy Damage taken
    public void PlayDamageTakenBigEnemy()
    {
        if (damageClipBigEnemy != null)
        {
            audioSource.PlayOneShot(damageClipBigEnemy, damageVolumeBigEnemy);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
    
    //Big Enemy Damage taken
    public void PlayBulletSplitting()
    {
        if (BulletSplittingClip != null)
        {
            audioSource.PlayOneShot(BulletSplittingClip, BulletSplittingVolume);
            //Vary audio pitch  
            if (varyPitch) { audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
}
