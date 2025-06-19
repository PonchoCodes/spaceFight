using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public void Hit()
    {
        Destroy(gameObject);        
    }
    //Getter
    public int GetDamage()
    {
        return damage;
    }

    
}
