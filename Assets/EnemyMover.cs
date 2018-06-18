using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    private Waypoint[] blocks;
    [SerializeField] List<Waypoint> path;
	// Use this for initialization
	void Start () {
        // Create the array blocks
        Waypoint[] blocks = FindObjectsOfType<Waypoint>();

        // Create new List with initial capacity
        path = new List<Waypoint>(blocks.Length);

        // Add all blocks to the list
        foreach (Waypoint block in blocks)
        {
            path.Add(block);
        }

        StartCoroutine(followPath());
    }


   IEnumerator followPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f); 
        }
    }
}
