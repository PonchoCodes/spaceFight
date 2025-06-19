using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 0.1f;

    Coroutine firingCoroutine;

    public bool isFiring;

    void Start()
    {

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
            if(rb != null) { rb.linearVelocity = transform.up * projectileSpeed; }
            Destroy(projectile, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }     
    }
}
