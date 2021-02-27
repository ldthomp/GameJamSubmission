using CartoonFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Combat
{
    public class FireballBehaviour : MonoBehaviour
    {
        [SerializeField] float fireballRange = 8f;

        //add in for amending fireball rate and cooldowns. Would require a timer.
        //[SerializeField] float nextFireball = 5f;
        //[SerializeField] float fireballRate = 5f;
        
        [SerializeField] GameObject fireballPrefabVFX;
        [SerializeField] GameObject fireballSpawnPoint;


        float fireballAnimLength = 0.19f;


        private void Start()
        {
            
        }
        private void Update()
        {

        }
        public void ShootFireball ()
        {
            //print("shooting fireball");
            StartCoroutine(Shoot());


        }

        IEnumerator Shoot()
        {
            print("shooting fireball");
            GetComponent<Animator>().SetTrigger("Fireball Attack");

            yield return new WaitForSeconds(fireballAnimLength);
            GetComponent<Animator>().ResetTrigger("Fireball Attack");
            GameObject fireball = Instantiate(fireballPrefabVFX, fireballSpawnPoint.transform.position, fireballSpawnPoint.transform.rotation); //todo max amount at one time = 1
            //GetComponent<MoveFireball>().FireballMovement();
            DestroyFireball(fireball);
            

            //fireballFX.SetActive(true);
        }



        private void DestroyFireball(GameObject fireball)
        {
            Destroy(fireball, fireballRange);
        }
    }
}