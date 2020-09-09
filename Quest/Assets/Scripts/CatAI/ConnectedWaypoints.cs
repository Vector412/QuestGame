using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public class ConnectedWaypoints : WayPoint
    {
        [SerializeField]
        protected float _connectivityRadius = 50f;
        List<ConnectedWaypoints> _connections;
        void Start()
        {
            GameObject[] allWayPoints = GameObject.FindGameObjectsWithTag("Waypoint");
            _connections = new List<ConnectedWaypoints>();
            for (int i = 0; i < allWayPoints.Length; i++)
            {
                ConnectedWaypoints nextWaypoint = allWayPoints[i].GetComponent<ConnectedWaypoints>();
                if(nextWaypoint != null)
                {
                    //if(Vector3.Distance(this.transform.position))
                }
            }
        }


    }
}
