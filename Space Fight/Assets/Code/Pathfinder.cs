using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] bool loopRoute;
    //Reference to the Wave Config SO
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    // Allows us to keep track of what waypoint we are on
    int waypointIndex = 0;

    void Awake()
    {
        // Find our enemySpawner Class, also FindObjectOfType was deprecated so that's why we use FindFirstObjectByType instead
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

  void Start()
    {
        //Defines our waveConfig as the current wave from the EnemySpawner class
        waveConfig = enemySpawner.GetCurrentWave();
        // Populate our waypoints list
        waypoints = waveConfig.GetWaypoints();
        //Sets our enemy position to the current waypoint
        transform.position = waypoints[waypointIndex].position;
    }


    void Update()
    {
        FollowPath();
    }

    // Moves position towards next waypoint's position
    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            // set the target position to the position of our waypoint
            Vector3 targetPosition = waypoints[waypointIndex].position;
            // Get enemy speed from scriptable object and make fps independent by multiplying by time.deltatime
            float enemySpeed = waveConfig.GetMoveSpeed() * Time.deltaTime;
            // Moves our enemy towards position
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemySpeed);
            if (transform.position == targetPosition)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
