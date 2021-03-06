﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] float attackRange;
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] Waypoint waypoint;

    Transform targetEnemy;




    // Update is called once per frame
    void Update () {
        SetTarget();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
	}

    private void SetTarget()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distA = Vector3.Distance(transform.position, transformA.position);
        var distB = Vector3.Distance(transform.position, transformB.position);

        if (distA < distB)
        { return transformA; }

        else { return transformB; }

    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy < attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

    public void setBase(Waypoint newbase)
    {
        waypoint = newbase;
    }
    public Waypoint getBase()
    {
        return waypoint;
    }
}
