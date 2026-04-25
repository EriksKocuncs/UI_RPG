using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private string charName;

    public string CharName
    {
        get { return charName; }
    }

    [SerializeField] private float health;

    public float MaxHealth;
    public float Health
    {
        get { return health; }
        set { health = Mathf.Max(0, value); }
    }

    private void Awake()
    {
        health = MaxHealth;
    }

    // public string charName;
    // public float health;
    public abstract void Attack( Character toHit);
    
    public void GetHit(float damage)
    {
        health = Health - damage;
        Debug.Log(charName + " get hit by " + damage + "! Health: " + Health);
    }

    public void GetHit(Weapon weapon)
    {
        health = Health - weapon.GetDamage();
        Debug.Log(charName + " get hit by " + weapon.name + "! Health: " + Health);
    }
    
}
