using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    static public Main SingleMain;

    public List<GameObject> prefabsEnemies;

    public float enemySpawnPerSecond = 0.5f;
    public float enemyPadding = 1.5f;
 

    private void Awake()
    {
        SingleMain = this;
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    public void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, prefabsEnemies.Count);

        GameObject enemy = Instantiate<GameObject>(prefabsEnemies[randomEnemy]);



        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector3 position = Vector3.zero;
        position.x = Random.Range(min.x, max.x);
        position.y = max.y;
        enemy.transform.position = position;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }
}
