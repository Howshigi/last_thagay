using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;

    public Wave wave;
    private int spawnedEnemies = 0;
    private float nextSpawnTime = 0;

    public void ChangeWave(Wave wave)
    {
        this.wave = wave;
        spawnedEnemies = 0;
        nextSpawnTime = Time.time;
    }

    public bool IsCompleted()
    {
        return spawnedEnemies >= wave.enemyCount;
    }

    void Update()
    {


        float t = Time.time;

        if (spawnedEnemies < wave.enemyCount && t > nextSpawnTime)
        {
            Spawn();
            spawnedEnemies++;
            nextSpawnTime = t + wave.spawnInterval;
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, wave.enemyProfebs.Length);
        int pointIndex = Random.Range(0, spawnPoints.Length);

        var prefab = wave.enemyProfebs[enemyIndex];
        var point = spawnPoints[pointIndex];

        Instantiate(
            prefab,
            point.position,
            Quaternion.Euler(0, 180, 0)
        );
    }
}
