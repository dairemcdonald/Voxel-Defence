using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    //Pathfinding
    public bool isExplored = false;
    public Waypoint exploredFrom;

    //Tower placement
    [SerializeField] Tower towerPrefab;
    public bool isPlaceable = true;

    //Grid Setup
    Vector2Int gridPos;
    const int gridSize = 10;

    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int getGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) ,
            Mathf.RoundToInt(transform.position.z / gridSize) 
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
            }

            else
            {
                print("Cannot place here");
            }
        }
    }
}
