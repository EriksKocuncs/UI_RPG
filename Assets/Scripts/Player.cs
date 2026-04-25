using UnityEngine;

public class Player : Character
{
    
    [SerializeField] private Weapon[] weapons;
    private int currentWeaponIndex = 0;
    private Weapon selectedWeapon => weapons[currentWeaponIndex];
    public override void Attack(Character toHit)
    {
        toHit.GetHit(selectedWeapon);
    }

    public bool CanHit(Character target)
    {
        if (target is Mosquito && selectedWeapon is not FlySwatter) return false;
        if (selectedWeapon is FlySwatter && target is not Mosquito) return false;
        return true;
    }

    public void SwitchWeapon()
    {
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
    }
    public void Heal(Character toHeal)
    {
        if (Health >= MaxHealth-10)
        {
            Health = MaxHealth;
        } 
        else 
        {
            Health += 10;
        }
    }

    public string GetWeaponName()
    {
        return selectedWeapon.name;
    }
}
