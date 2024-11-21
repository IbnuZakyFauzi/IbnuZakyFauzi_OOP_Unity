using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy; // Referensi prefab enemy yang akan di-spawn

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3; // Minimum kill untuk menaikkan jumlah spawn
    public int totalKill = 0; // Total kill global
    private int totalKillWave = 0; // Kill per wave

    [SerializeField] private float spawnInterval = 3f; // Waktu antar spawn

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0; // Jumlah enemy yang telah di-spawn
    public int defaultSpawnCount = 1; // Default jumlah enemy per spawn
    public int spawnCountMultiplier = 1; // Pengali jumlah spawn
    public int multiplierIncreaseCount = 1; // Kenaikan multiplier

    public CombatManager combatManager; // Referensi ke CombatManager

    public bool isSpawning = false; // Status apakah spawner aktif

    private void Start()
    {
        StartSpawning(); // Memulai proses spawning saat game dimulai
    }

    private void Update()
    {
        if (!isSpawning) return;

        if (combatManager != null && totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier += multiplierIncreaseCount;
            totalKillWave = 0; // Reset kill per wave
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnEnemies), 0, spawnInterval);
    }

    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnEnemies));
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = defaultSpawnCount * spawnCountMultiplier;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(spawnedEnemy);
            spawnCount++;
        }
    }

    public void RegisterKill()
    {
        totalKill++;
        totalKillWave++;
    }
}
