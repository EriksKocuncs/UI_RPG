using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] internal float damage;

    public virtual float GetDamage()
    {
        return damage;
    }
    
}
