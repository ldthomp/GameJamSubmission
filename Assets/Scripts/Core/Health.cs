using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float healthPoints = 100f;

        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print("Health =" + healthPoints);
            if (healthPoints == 0)
            {
                Death();
            }
        }

        private void Death()
        {
            if (isDead) { return; }
            isDead = true;
            if (gameObject.GetComponent<Animator>() == null) return;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<ActionScheduler>().CancelCurentAction();
        }
        public float GetHealthPoints()
        {
            return healthPoints;
        }    
    }

}