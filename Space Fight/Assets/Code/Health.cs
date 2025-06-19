using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    //On collision
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Check if other collider has a damage dealer script and define it
        DamageDealer damageDealer = otherCollider.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            damageDealer.Hit();
            TakeDamage(damageDealer.GetDamage());
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
}
