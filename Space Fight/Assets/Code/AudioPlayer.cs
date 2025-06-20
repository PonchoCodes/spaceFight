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
    //To note is the Range modifier which adds a set range in the inspector and a slider
    [SerializeField][Range(0f, 1f)] float playerShootingVolume = 1f;
    [SerializeField][Range(0f, 1f)] float enemyShootingVolume = 1f;


    // Player Shooting
    public void PlayShootingClipPlayer()
    {
        if (shootingClipPlayer != null)
        {
            audioSource.PlayOneShot(shootingClipPlayer, playerShootingVolume);
            //Vary audio pitch  
            if (varyPitch) {audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
    //Enemy Shooting
    public void PlayShootingClipEnemy()
    {
        if (shootingClipEnemy != null)
        {
            audioSource.PlayOneShot(shootingClipEnemy, enemyShootingVolume);
            //Vary audio pitch  
            if (varyPitch) {audioSource.pitch = Random.Range(1 - pitchVariance, 1 + pitchVariance); }
        }
    }
}
