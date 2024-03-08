using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 몬스터 프리팹 배열
    public BoxCollider2D spawnArea; // 스폰 영역을 나타내는 콜라이더
    public float minSpawnInterval = 1f; // 최소 스폰 간격
    public float maxSpawnInterval = 3f; // 최대 스폰 간격

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMonster();
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnMonster()
    {
        int randomIndex = Random.Range(0, monsterPrefabs.Length);
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x), 
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y), 
            0); // Z축은 필요에 따라 조절

        Instantiate(monsterPrefabs[randomIndex], spawnPosition, Quaternion.identity);
    }
}

