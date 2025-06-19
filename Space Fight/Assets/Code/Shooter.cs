using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.1f;

    [Header("AI")]
    [SerializeField] bool UseAI = false;

    Coroutine firingCoroutine;

    public bool isFiring;

    void Start()
    {
        if (UseAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        // If I am firing and there and firing Coroutine = null start the firing coroutine
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        // If im not firing and firing coroutine is something other than null then set firing coroutine to null and stop it
        else if (!isFiring && firingCoroutine != null) { StopCoroutine(firingCoroutine); firingCoroutine = null; }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            //Create projectile
            GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
            //Get a rb reference to the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            //IF rb found
            if (rb != null)
            {
                if (UseAI)
                {
                    rb.linearVelocity = transform.up * -projectileSpeed;
                }
                else {rb.linearVelocity = transform.up * projectileSpeed;}
                
            }
            //Destroy after x seconds
            Destroy(projectile, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }     
    }
}
