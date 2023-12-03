using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public Transform playerTransform;
    public float minSpawnDistance = 2f;
    public float maxSpawnDistance = 5f;
    public float minSpawnHeight = -1f; // Valor mínimo para a posição Z
    public float maxSpawnHeight = 1f;  // Valor máximo para a posição Z
    public float minSpawnWight = 1f; // Valor mínimo para a posição Y
    public float maxSpawnWight = 2f;  // Valor máximo para a posição Y
    public int maxPlatforms = 10;

    private List<GameObject> spawnedPlatforms = new List<GameObject>();

    void Start()
    {
        SpawnInitialPlatforms();
    }

    void Update()
    {
        if (playerTransform.position.x > spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.x - minSpawnDistance)
        {
            SpawnPlatform();
            DestroyOldestPlatform();
        }
    }

    void SpawnInitialPlatforms()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

void SpawnPlatform()
{
    GameObject randomPlatformPrefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];

    float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
    float randomHeight = Random.Range(minSpawnHeight, maxSpawnHeight);
    float randomWight = Random.Range(minSpawnWight, maxSpawnWight);

    float previousPlatformY = spawnedPlatforms.Count > 0
        ? spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position.y
        : 0f;
    Debug.Log(randomWight);
    Vector3 spawnPosition = spawnedPlatforms.Count == 0
        ? new Vector3(3f, randomWight, randomHeight)
        : spawnedPlatforms[spawnedPlatforms.Count - 1].transform.position + new Vector3(randomDistance, randomWight - previousPlatformY, randomHeight);

    Quaternion spawnRotation = randomPlatformPrefab.transform.rotation;

    GameObject newPlatform = Instantiate(randomPlatformPrefab, spawnPosition, spawnRotation);
    spawnedPlatforms.Add(newPlatform);
}






    void DestroyOldestPlatform()
    {
        if (spawnedPlatforms.Count > maxPlatforms)
        {
            Destroy(spawnedPlatforms[0]);
            spawnedPlatforms.RemoveAt(0);
        }
    }
}
