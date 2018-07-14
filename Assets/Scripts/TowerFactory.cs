using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;

    public void AddTower(Waypoint baseWaypoint)
    {
        var towers = FindObjectsOfType<Tower>();
        int numTowers = towers.Length;

        if (numTowers < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }

        else
        {
            MoveTower();
        }
          
    }

    public void InstantiateTower(Waypoint baseWaypoint)
    {
        var towerTemp = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerTemp.transform.parent = this.transform;
        baseWaypoint.isPlaceable = false;
    }

    public void MoveTower()
    {
        print("Tower Limit Reached"); 
    }
}
