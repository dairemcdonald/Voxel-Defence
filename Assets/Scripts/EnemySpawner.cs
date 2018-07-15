using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] int enemyNum = 4;
    [SerializeField] Text waveText;

    public EnemyMover prefab;

    void Start()
    {
        StartCoroutine(Spawn());
        waveText.text = enemyNum.ToString();
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            var tempInt = Instantiate(prefab, transform.position, Quaternion.identity);
            tempInt.transform.parent = this.transform;
            waveText.text = ((enemyNum - i)-1).ToString(); //subtracts already spawned enemies from total expected 
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    
}
