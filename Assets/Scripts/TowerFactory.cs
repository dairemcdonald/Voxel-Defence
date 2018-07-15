using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {
    [SerializeField] int towerLimit = 4;
    [SerializeField] Tower towerPrefab;
    [SerializeField ]Queue<Tower> towers = new Queue<Tower>();

  
    public void AddTower(Waypoint baseWaypoint)
    {

        int numTowers = towers.Count;

        if (numTowers < towerLimit)
        {
            InstantiateTower(baseWaypoint);
        }

        else
        {
            MoveTower(baseWaypoint);
        }
          
    }

    public void InstantiateTower(Waypoint baseWaypoint)
    {
        var towerToAdd = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towerToAdd.transform.parent = this.transform;
        towerToAdd.setBase(baseWaypoint);
        towers.Enqueue(towerToAdd);
        baseWaypoint.isPlaceable = false;
    }

    public void DisistantiateTower()
    {
        var towerToRemove = towers.Dequeue();
        towerToRemove.getBase().isPlaceable = true;
        Destroy(towerToRemove.gameObject);
    }

    public void MoveTower(Waypoint baseWaypoint)
    {
        DisistantiateTower();
        InstantiateTower(baseWaypoint);
       
    }
}
