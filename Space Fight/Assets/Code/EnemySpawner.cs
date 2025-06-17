using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    void SpawnEnemies()
    {
        // Spawns enemy at the location of the starting waypoint, notably quaternion is how unity handles rotations, and to specify no rotation we use `Quaternion.identity`
        Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position, Quaternion.identity );
    }
}
