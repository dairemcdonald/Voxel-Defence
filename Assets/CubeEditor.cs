using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
    [Range(1f, 20f)] [SerializeField] float gridsize = 10f;

    TextMesh textmesh;
    // Update is called once per frame
    void Update () {
        Vector3 snapPos;
        
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridsize) * gridsize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridsize) * gridsize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textmesh = GetComponentInChildren<TextMesh>();
        textmesh.text = snapPos.x / gridsize + "," + snapPos.z / gridsize;
	}
}
