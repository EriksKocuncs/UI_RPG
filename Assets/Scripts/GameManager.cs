using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Character selectedChar;

    public Player player;

    public Enemy currentEnemy;
    [SerializeField] private TMP_Text playerName, playerHP, enemyName, enemyHP, currentWeaponTXT, combatMessage;
    [SerializeField] private Image enemyPreview;
    [SerializeField] private Enemy[] allEnemies;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private AudioClip attackSound, healthSound;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverCanvas.gameObject.SetActive(false);
        combatMessage.gameObject.SetActive(false);
        SetCurrentEnemy();
        RefreshUI();
    }
    public void Fight()
    {
        if (!player.CanHit(currentEnemy))
        {
            combatMessage.gameObject.SetActive(true);
            return;
        }
        combatMessage.gameObject.SetActive(false);
        player.Attack(currentEnemy);
        if (currentEnemy.Health <= 0)
        {
            currentEnemy.audioSource.PlayOneShot(currentEnemy.deathSound);
            SetCurrentEnemy();
        }
        else
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(attackSound);
            currentEnemy.Attack(player);
        }
        //currentEnemy.Attack(player);
        RefreshUI();
    }

    public void HealingButton()
    {
        audioSource.PlayOneShot(healthSound);
        player.Heal(player);
        RefreshUI();
    }

    private void SetCurrentEnemy()
    {
        int enemyIndex = Random.Range(0, allEnemies.Length);
        currentEnemy = allEnemies[enemyIndex];
        currentEnemy.Reset();
    }

    public void RefreshUI()
    {
        currentWeaponTXT.text = "Current Weapon: " + player.GetWeaponName();
        playerName.text = player.CharName;
        playerHP.text = "HP:" + player.Health.ToString("F1");
        
        enemyName.text = currentEnemy.CharName;
        enemyHP.text = "HP:" + currentEnemy.Health.ToString("F1");
        enemyPreview.sprite = currentEnemy.enemyImage;
    }

    private void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchWeaponButton()
    {
        player.SwitchWeapon();
        RefreshUI();
    }
    
    void Update()
    {
        if (player.Health <= 0)
        {
            GameOver();
        }
    }
}
