using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] int hp = 10;

	// Use this for initialization
	void Start () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hp <= 0)
        {
            KillEnemy();
        }
    }


    void ProcessHit()
    {
        hp--;
        print("current hp: " + hp);
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
