using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Allows us to create this asset in Unity
[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;


    // ------------------------------- GETTERS ----------------------
    //Get the first path
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

     //Get the first path
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

     //Get the first path
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    //Get all of the waypoints
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

}
