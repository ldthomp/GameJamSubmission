using UnityEngine.AI;
using UnityEngine;
using DungeonCrawl.Core;

namespace DungeonCrawl.Movement
{
    public class Mover : MonoBehaviour , IAction
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed = 6f;
        float speed; 

        NavMeshAgent navMeshAgent;
        Health health;
        Animator animator;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();

            UpdateGroundMovementAnimator();
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(gameObject.tag == "Player")
                {
                    UpdateFlyMovementAnimator();
                }
            }

        }
        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {

            navMeshAgent.enabled = true;
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
            

        }
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateGroundMovementAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
            animator.SetFloat("ForwardSpeed", speed);
        }

        private void UpdateFlyMovementAnimator()
        {
            animator.SetTrigger("Fly");
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            speed = localVelocity.z;
            animator.SetFloat("ForwardSpeed", speed);
        }
    }

}