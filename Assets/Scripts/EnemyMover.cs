using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float movementDelay;
    [SerializeField] ParticleSystem baseDeathParticle;
    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementDelay);
        }

        selfDestruct();
    }

    private void selfDestruct()
    {
        var vfx = Instantiate(baseDeathParticle, transform.position, Quaternion.identity);
        vfx.transform.parent = GameObject.Find("Clutter").transform;
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
