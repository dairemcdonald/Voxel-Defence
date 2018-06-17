using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    private Block[] blocks;
    [SerializeField] List<Block> path;
	// Use this for initialization
	void Start () {
        // Create the array blocks
        Block[] blocks = FindObjectsOfType<Block>();

        // Create new List with initial capacity
        path = new List<Block>(blocks.Length);

        // Add all blocks to the list
        foreach (Block block in blocks)
        {
            path.Add(block);
        }

        PrintWaypoints();
    }

    private void PrintWaypoints()
    {
        foreach (Block waypoint in path)
        {
            print(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
