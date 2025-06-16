using System.Collections.Generic;
using UnityEngine;

//Allows us to create this asset in Unity
[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    //Get the first path
    public Transform getStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
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
