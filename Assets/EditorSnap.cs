using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {
    [Range(1f, 20f)] [SerializeField] float gridsize;

    // Update is called once per frame
    void Update () {
        Vector3 snapPos;
        
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * gridsize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * gridsize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
	}
}
