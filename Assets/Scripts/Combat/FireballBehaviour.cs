using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Combat
{
    public class FireballBehaviour : MonoBehaviour
    {
        [SerializeField] float fireballRange = 8;

        private void Start()
        {

        }
        private void Update()
        {
            print(fireballRange * Time.deltaTime);
        }

        private void OnEnable()
        {
            transform.localPosition = Vector3.forward * Time.deltaTime;
        }
    }

}