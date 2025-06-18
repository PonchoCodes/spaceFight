using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    //Coroutine to spawn enemies
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            // Spawns enemy at the location of the starting waypoint, notably quaternion is how unity handles rotations, and to specify no rotation we use `Quaternion.identity`
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity);
            // Waits for time defined in wave config
            yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        }

    }
    
}
