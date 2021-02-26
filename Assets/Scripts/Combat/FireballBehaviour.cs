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
        [SerializeField] GameObject fireballFX;

        Ray lastRay;

        private void Start()
        {

        }
        private void Update()
        {
            //print(fireballRange * Time.deltaTime);
        }
        public void ShootFireball ()
        {
            lastRay = new Ray (transform.position,Vector3.forward);
            Debug.DrawRay(transform.position, Vector3.forward, Color.white * 100);

            print("shooting fireball");
            //GetComponent<Animator>().SetTrigger("Fireball Attack");
            //fireballFX.SetActive(true);
        }

        private void OnEnable()
        {
            transform.localPosition = Vector3.forward * Time.deltaTime;
        }
    }

}