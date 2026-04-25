using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float minDamage, maxDamage;
    public AudioClip deathSound;
    public AudioSource audioSource;
    public Sprite enemyImage;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void Attack(Character toHit)
    {
        float damage = Random.Range(minDamage, maxDamage);
        toHit.GetHit(damage);
        Debug.Log("Enemy; - Attack player");
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
}
