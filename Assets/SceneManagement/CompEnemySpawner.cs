using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompEnemySpawner : MonoBehaviour
{
    CompleteScript completionScript;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject player;
    [SerializeField] Transform boat;
    private float spawnTime;
    private float spawnCooldown;
    void Start()
    {
        completionScript = GetComponent<CompleteScript>();
        spawnTime = Time.time;
        spawnCooldown = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (completionScript.complete == true)
        {
            if (spawnTime + spawnCooldown < Time.time)
            {
                spawnTime = Time.time;
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position =
                    new Vector3(boat.position.x, boat.position.y, boat.position.z)
                    + new Vector3(
                        Random.Range(10f, 30f) * Random.Range(1f, -1f), 
                        Random.Range(10f, 30f) * Random.Range(1f, -1f), 
                        Random.Range(10f, 30f) * Random.Range(1f, -1f));
                EyeFollow enemyScript = enemy.GetComponent<EyeFollow>();
                enemyScript.player = player;
            }
        }
    }
}
