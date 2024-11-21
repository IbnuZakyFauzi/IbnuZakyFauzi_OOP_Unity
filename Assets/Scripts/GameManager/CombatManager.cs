using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners; // Daftar EnemySpawner dalam gim
    public float timer = 0f; // Timer untuk wave
    [SerializeField] private float waveInterval = 5f; // Interval antar wave
    public int waveNumber = 1; // Nomor wave saat ini
    public int totalEnemies = 0; // Total musuh dalam wave ini

    private void Start()
    {
        StartWave(); // Memulai wave pertama
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waveInterval && AllEnemiesDefeated())
        {
            timer = 0f;
            StartWave();
        }
    }

    private bool AllEnemiesDefeated()
    {
        foreach (var spawner in enemySpawners)
        {
            if (spawner.spawnCount > spawner.totalKill)
                return false; // Masih ada musuh yang belum dikalahkan
        }
        return true;
    }

    private void StartWave()
    {
        waveNumber++;
        Debug.Log($"Wave {waveNumber} started!");

        foreach (var spawner in enemySpawners)
        {
            spawner.defaultSpawnCount = waveNumber; // Meningkatkan jumlah spawn sesuai wave
            spawner.StartSpawning(); // Memulai spawning musuh
        }

        totalEnemies = CalculateTotalEnemies();
    }

    private int CalculateTotalEnemies()
    {
        int total = 0;
        foreach (var spawner in enemySpawners)
        {
            total += spawner.defaultSpawnCount * spawner.spawnCountMultiplier;
        }
        return total;
    }
}