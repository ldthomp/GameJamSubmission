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
        [SerializeField] float stoppingDistanceForCombat = 5f;
        NavMeshAgent navMeshAgent;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();

        }

        private void Update()
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                // stopping distance must be 0 for WASD keys
                if(navMeshAgent.stoppingDistance > 0f)
                {
                    navMeshAgent.stoppingDistance = 0f;
                }
                StartMoveAction();
            }

            UpdateAnimator();
        }

        public void StartMoveAction()
        {
            float horInput = Input.GetAxis("Horizontal");
            float verInput = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horInput, 0f, verInput);
            Vector3 moveDestination = transform.position + movement;
            GetComponent<NavMeshAgent>().destination = moveDestination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("ForwardSpeed", speed);
        }
        public void MoveToCombat (Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.stoppingDistance = stoppingDistanceForCombat;
            navMeshAgent.isStopped = false;
        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }
    }

}