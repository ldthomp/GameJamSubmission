using DungeonCrawl.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.CrossPlatformInput;

namespace DungeonCrawl.Movement
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

        }

        private void Update()
        {
            //print(navMeshAgent.destination);
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                GetComponent<Fighter>().Cancel();
                StartMoveAction();
            }
            UpdateAnimator();
        }

        public void Stop()
        {
            navMeshAgent.isStopped = true;
        }

        public void StartMoveAction()
        {
            float horInput = Input.GetAxis("Horizontal");
            float verInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horInput, 0f, verInput);
            Vector3 moveDestination = transform.position + movement;
            //navMeshAgent.destination = moveDestination; destination now only set by one method
            float stoppingDistanceMovement = 0f;
            SetDestination(moveDestination, stoppingDistanceMovement);
        }

        public void SetDestination (Vector3 destination, float stoppingDistance)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.stoppingDistance = stoppingDistance;
            navMeshAgent.isStopped = false;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
    }

}