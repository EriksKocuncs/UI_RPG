using UnityEngine;

public class CritWeapon : Weapon
{
    [SerializeField] private float critChance = 0.3f;

    public override float GetDamage()
    {
        if (Random.value < critChance)
        {
            Debug.Log("Critical hit!");
            return damage * 2;
        }
        return damage;
    }
}
