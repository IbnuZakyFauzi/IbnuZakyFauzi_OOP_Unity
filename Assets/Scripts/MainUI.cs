using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text healthText;
    public Text pointsText;
    public Text waveText;
    public Text enemiesLeftText;

    private int playerHealth = 100;
    private int points = 0;
    private int currentWave = 1;
    private int enemiesLeft = 5;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = "Health: " + playerHealth;
        pointsText.text = "Points: " + points;
        waveText.text = "Wave: " + currentWave;
        enemiesLeftText.text = "Enemies Left: " + enemiesLeft;
    }

    public void EnemyKilled(int enemyLevel)
    {
        points += enemyLevel;
        enemiesLeft--;

        if (enemiesLeft <= 0)
        {
            NextWave();
        }

        UpdateUI();
    }

    private void NextWave()
    {
        currentWave++;
        enemiesLeft = currentWave * 5; // Example: increase enemies with wave
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("Game Over");
        }

        UpdateUI();
    }
}
