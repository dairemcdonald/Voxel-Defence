using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.getGridSize();
        transform.position = new Vector3(
            waypoint.getGridPos().x,
            0f,
            waypoint.getGridPos().y
        );
    }

    private void UpdateLabel()
    {
       TextMesh textMesh = GetComponentInChildren<TextMesh>();
       int gridSize = waypoint.getGridSize();

        string labelText =
                waypoint.getGridPos().x / gridSize +
                "," +
               waypoint.getGridPos().y / gridSize;

        textMesh.text = labelText;
        gameObject.name = labelText;
     }
}
