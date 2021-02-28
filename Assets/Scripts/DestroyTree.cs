using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Control
{
    public class DestroyTree : MonoBehaviour
    {
        private void OnParticleCollision(GameObject other)
        {
            Destroy(gameObject);
        }
    }

}