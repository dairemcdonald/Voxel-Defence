using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    [SerializeField] int hp = 10;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem hitParticle;

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
        hitParticle.Play();
        hp--;
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }
}
