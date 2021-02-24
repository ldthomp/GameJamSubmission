using DungeonCrawl.Core;
using DungeonCrawl.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DungeonCrawl.Combat
{
    public class Fighter : MonoBehaviour
    {
        Health target;
        Mover movePlayer;
        [SerializeField] float weaponRange = 5f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 10f;

        float timeSinceLastAttack = Mathf.Infinity;
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, weaponRange);
        }

        private void Start()
        {
            movePlayer = GetComponent<Mover>();
        }
        void Update()
        {
            if (InteractWithCombat()) return;
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead()) return;

            if (GetIsInRange())
            {
                print("player is in range and will stop");
                movePlayer.Stop();
            }
            else
            {
                Debug.Log(gameObject.name + " mover is being cancelled");
                //movePlayer.Cancel(); //stops Navmesh
                AttackBehaviour();
            }
        }
        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {

                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (!GetComponent<Fighter>().CanAttack(target.gameObject))
                {
                    continue;
                }
                if (Input.GetMouseButton(0))
                
                {
                    movePlayer.SetDestination(target.transform.position, weaponRange);
                    GetComponent<Fighter>().Attack(target.gameObject);
                    //navmeshagent stopping distance = weaponrange from fighter
                    
                }
                
                return true;
            }
            return false;
        }
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void Attack(GameObject combatTarget)
        {
            target = combatTarget.transform.GetComponent<Health>();
            //move to target
            //stop within range
            //check distance 
            //check it is moving away
        }
        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                //this will trigger Hit() event
                TriggerAttack();
                timeSinceLastAttack = 0f;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttacking");
            Debug.Log("resetting stop attacking trigger of " + gameObject.name);
            GetComponent<Animator>().SetTrigger("Attack");
        }

        //Animation Event on Attack
        void Hit()
        {
            if (target == null) return;
            target.TakeDamage(weaponDamage);
            print("Enemy Taking a Hit");
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
        }

        public void Cancel()
        {
            StopAttack();
            target = null;
            movePlayer.Cancel();
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("Attack");
            GetComponent<Animator>().SetTrigger("stopAttacking");
            Debug.Log("setting stop attacking trigger of " + gameObject.name);
        }
    }
}