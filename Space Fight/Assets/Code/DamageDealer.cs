using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] int damage = 10;

    [Header("Special Bullet")]
    [SerializeField] bool explodesIntoMoreBullets;
    [SerializeField] float shatterBulletSpeed;
    [SerializeField] int amountOfDesiredBullets;
    [SerializeField] int timeBeforeShatter;
    AudioPlayer audioPlayer;
    [SerializeField] GameObject shatterBulletPrefab;

    private void Awake()
    {
    audioPlayer = FindFirstObjectByType<AudioPlayer>();    
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
    //Getter
    public int GetDamage()
    {
        return damage;
    }

    //Shatter into more bullets
    public void Shatter()
    {
        int bulletsSpawned = 0;
        int rotation = 0;
        while (amountOfDesiredBullets > bulletsSpawned)
        {
            Quaternion bulletRotation = Quaternion.Euler(0, 0, rotation);
            GameObject shatterBullet = Instantiate(shatterBulletPrefab, transform.position, bulletRotation);
            rotation += 360 / amountOfDesiredBullets;

            //Get a rb reference to the projectile
            Rigidbody2D rb = shatterBullet.GetComponent<Rigidbody2D>();
            //IF rb found
            if (rb != null)
            {
                rb.linearVelocity = shatterBullet.transform.up * shatterBulletSpeed;
            }
            bulletsSpawned += 1;
        }
        audioPlayer.PlayBulletSplitting();
        Destroy(gameObject);
    }

    public void startBulletShatter()
    {
        Invoke("Shatter", timeBeforeShatter);
    }

    public bool GetExplodesIntoMoreBullets()
    {
        return explodesIntoMoreBullets;
    }
}
