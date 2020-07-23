using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    private const float SpawnLimitXLeft = -22;
    private const float SpawnLimitXRight = 7;
    private const float SpawnPosY = 30;
    private const float StartDelay = 1.0f;
    private const int StartSpawnIntervalRange = 3;
    private const int EndSpawnIntervalRange = 6;

    public GameObject[] ballPrefabs;
    private float _spawnInterval = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    // Spawn random ball at random x position at top of play area
    IEnumerator SpawnRandomBall()
    {
        yield return new WaitForSeconds(StartDelay);
        while (true)
        {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(SpawnLimitXLeft, SpawnLimitXRight), SpawnPosY, 0);

            // instantiate ball at random spawn location
            var ballPrefab = ballPrefabs[Random.Range(0, ballPrefabs.Length)];
            Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
            _spawnInterval = Random.Range(StartSpawnIntervalRange, EndSpawnIntervalRange);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}