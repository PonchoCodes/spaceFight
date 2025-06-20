using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
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
            AudioSource.PlayClipAtPoint(shootingClipPlayer, Camera.main.transform.position, playerShootingVolume);
        }
    }

    //Enemy Shooting
    public void PlayShootingClipEnemy()
    {
        if (shootingClipEnemy != null)
        {
            AudioSource.PlayClipAtPoint(shootingClipEnemy, Camera.main.transform.position, enemyShootingVolume);
        }
    }
}
