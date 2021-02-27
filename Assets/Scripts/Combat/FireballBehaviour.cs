using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Combat
{
    public class FireballBehaviour : MonoBehaviour
    {
        [SerializeField] float fireballRange = 8f;
        [SerializeField] float nextFireball = 5f;
        [SerializeField] float fireballRate = 5f;
        [SerializeField] GameObject fireballPrefabVFX;

        

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
            Instantiate(fireballPrefabVFX, transform.position, Quaternion.identity,transform);
            yield return new WaitForSeconds(fireballRange);
            Destroy(fireballPrefabVFX);
            //fireballFX.SetActive(true);
        }
    }
}