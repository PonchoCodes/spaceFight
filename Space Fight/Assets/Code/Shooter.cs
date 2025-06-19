using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Projectile Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float firingRate = 5f;

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
        if (isFiring) { StartCoroutine(FireContinously()); }
        else { StopCoroutine(FireContinously()); }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(projectile, projectileLifeTime);
            yield return new WaitForSeconds(firingRate);
        }     
    }
}
