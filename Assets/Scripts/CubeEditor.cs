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
            waypoint.getGridPos().x * gridSize,
            0f,
            waypoint.getGridPos().y * gridSize
        );
    }

    private void UpdateLabel()
    {
       TextMesh textMesh = GetComponentInChildren<TextMesh>();
       int gridSize = waypoint.getGridSize();

        string labelText =
                waypoint.getGridPos().x  +
                "," +
               waypoint.getGridPos().y ;

        textMesh.text = labelText;
        gameObject.name = labelText;
     }
}
