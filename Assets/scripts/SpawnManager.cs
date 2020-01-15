using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private float spawnRate = 2.5f;
    private bool stopSpawning = false;

    // IEnumerator Start() 
    // {
    //     yield return StartCoroutine("Spawn");
    // }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(!stopSpawning)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-14f, 14f), 11, 0), Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void OnPlayerDeath() 
    {
        stopSpawning = true;
    }
}
