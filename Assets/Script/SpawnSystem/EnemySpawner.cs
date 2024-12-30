using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawRate = 1f;
    public Transform[] SpawnPoint;
    [SerializeField] private GameObject[] enemy;
    bool canSpawn = true;


    private void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawRate);
        while (canSpawn)
        {
            yield return wait;

            int randEnemy = Random.Range(0, enemy.Length);
            int randPoint = Random.Range(0, SpawnPoint.Length);
            GameObject enemyToSpawn = enemy[randEnemy];

            Instantiate(enemyToSpawn, SpawnPoint[randPoint].position, Quaternion.identity);
        }
    }
}



