using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public GameObject playerPrefab;        // Drag your player prefab here
    public Transform spawnPoint;           // Drag your spawn point here

    private GameObject spawnedPlayer;

    void Start()
    {
        if (playerPrefab && spawnPoint)
        {
            spawnedPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Player prefab or spawn point not assigned.");
        }
    }
}