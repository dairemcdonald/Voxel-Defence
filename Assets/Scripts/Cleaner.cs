using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {
    public float delay = 5f;
    //Destroys unused instances after certain delay
    void Start()
    {
        StartCoroutine(Clean());
    }

    IEnumerator Clean()
    {
            gameObject.transform.parent = GameObject.Find("Clutter").transform;
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
    }
}
