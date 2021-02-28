using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Control
{
    public class IceBlockDestroy : MonoBehaviour
    {
        [SerializeField] float hitpoints = 3;
        Vector3 transformScale;

        private void Start()
        {
            transformScale = transform.localScale;
        }
        private void OnParticleCollision(GameObject other)
        {
            if (hitpoints <= 0f)
            {
                Destroy(gameObject);
            }
            else
            {
                hitpoints -= 1f;
                transformScale.y = transformScale.y - 2f;
            }

        }
    }

}