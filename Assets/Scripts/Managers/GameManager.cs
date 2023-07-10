using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform spawnPoint;

    private GameObject playerInstance;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }
}