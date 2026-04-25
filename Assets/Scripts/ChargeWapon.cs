using UnityEngine;

public class ChargeWapon : Weapon
{
    [SerializeField] private float chargeAmount = 0.5f;
    private float charge = 0;

    public override float GetDamage()
    {
        float newdamage = damage + charge;
        charge += chargeAmount;
        return newdamage;
    }
}
