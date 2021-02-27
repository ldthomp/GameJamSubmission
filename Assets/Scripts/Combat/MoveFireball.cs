using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Combat
{
    public class MoveFireball : MonoBehaviour
    {
        [SerializeField] float fireballSpeed = 5f;
        [SerializeField] GameObject collisionExplosion;
        [SerializeField] float fireballDamage = 40;

        ParticleSystem.EmissionModule particle;

        bool hasCollided = false;

        private void Start()
        {
            particle = GetComponent<ParticleSystem>().emission;
        }
        private void Update()
        {
            if(hasCollided == false)
            {
                transform.position += transform.forward * fireballSpeed * Time.deltaTime;
            }
        }
        private void OnParticleCollision(GameObject other)
        {
            if(other.GetComponent<Health>() == true)
            {
                other.GetComponent<Health>().TakeDamage(fireballDamage);
            }

            particle.enabled = false;
            hasCollided = true;
            collisionExplosion.SetActive(true);
            // set active the boom VFX & stop current fire then fireball behaviour will destroy object.
        }
    }

}