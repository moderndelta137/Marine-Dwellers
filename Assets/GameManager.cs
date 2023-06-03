using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float enemyDuration=5.0f;
    float enemyTimer;
    [SerializeField] GameObject player;
    float enemySpawnRadius=10;
    float enemySpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyTimer = enemyDuration;
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {
            GameObject newEnemy= Instantiate(enemy, player.transform.position + Random.insideUnitSphere.normalized * enemySpawnRadius, Quaternion.identity);
            newEnemy.transform.position = new Vector3(newEnemy.transform.position.x, newEnemy.transform.position.y, 0.6f);
            newEnemy.GetComponent<Rigidbody>().velocity = ((player.transform.position - newEnemy.transform.position)*enemySpeed);
            enemyTimer = enemyDuration;
        }
    }
}
