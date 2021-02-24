using DungeonCrawl.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Items
{
    public class Item : MonoBehaviour
    {
        //[SerializeField] float hitPointMaxBonus = 100f;
        bool orbPickedUp = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                print("player is in range of orb");
                //other.GetComponent<Health>().IncreaseHealthPointMax(hitPointMaxBonus); Todo add in about increasing health
                orbPickedUp = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (orbPickedUp == true)
            {
                Destroy(GetComponent<SphereCollider>());
            }
        }

    }

}