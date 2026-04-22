using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public WaveController waveController;
    private int currentWave;
    void Start()
    {
       // waveController.ChangeWave(waves[0]);
    }

    void Update()
    {
        if (waveController.IsCompleted())
        {
            currentWave++;
            if (currentWave < waves.Length)
            {
                waveController.ChangeWave(waves[currentWave]);
            }

        }

    }
}