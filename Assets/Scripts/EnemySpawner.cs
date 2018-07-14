using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] int enemyNum = 4;
    public EnemyMover prefab;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            var tempInt = Instantiate(prefab, transform.position, Quaternion.identity);
            tempInt.transform.parent = this.transform;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
