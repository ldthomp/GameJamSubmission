using DungeonCrawl.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Items
{
    public class BlueOrbMovement : MonoBehaviour
    {
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolerance = 1f;
        [SerializeField] float waypointDwellTime = 3f;

        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        Vector3 orbPosition;

        int currentWaypointIndex = 0;

        private void Start()
        {
            orbPosition = transform.position;
        }

        private void Update()
        {
            PatrolBehaviour();
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }
    

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = orbPosition;
            if (patrolPath != null)
            {
                if (AtWaypoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }
            if (timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                transform.position = nextPosition;
            }
        }

        private bool AtWaypoint()
        {
            //return if at a waypoint
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private void CycleWaypoint()
        {
            //select next waypoint to move to
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }
    }

}