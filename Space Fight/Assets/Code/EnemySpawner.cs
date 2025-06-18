using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }


    //Coroutine to spawn enemies
    IEnumerator SpawnWaves()
    {

        foreach (WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for (int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                // Spawns enemy at the location of the starting waypoint, notably quaternion is how unity handles rotations, and to specify no rotation we use `Quaternion.identity`
                Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity);
                // Waits for time defined in wave config
                yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    // Getters
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    
}
