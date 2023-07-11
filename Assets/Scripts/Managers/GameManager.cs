using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Character playerPrefab;
    [SerializeField]
    private Transform spawnPoint;

    private Character playerInstance;

    private void Awake()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }

    public Character GetCharacter()
    {
        return playerInstance;
    }
}