using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

namespace Ancestors.SceneManagement
{
    public class SceneHandler : MonoBehaviour
    {
        enum destinationidentifier
        {
            a, b, c
        }
        [SerializeField] destinationidentifier destination;

        [SerializeField] int sceneToLoad = -1;
        [SerializeField] Transform spawnPoint;

        bool sceneLoadTrigger = false;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                print("Do you want to use the portal?  Y/N ");
                sceneLoadTrigger = true;
            }
        }


        private void Update()
        {

            if (sceneLoadTrigger == true && Input.GetKeyDown(KeyCode.Y))
            {
                StartCoroutine(Transition());

            }
        }
        IEnumerator Transition()
        {
            DontDestroyOnLoad(gameObject);
            yield return SceneManager.LoadSceneAsync(sceneToLoad);

            //gameObject.GetComponent<MeshRenderer>().enabled = false;

            //Transition for scene change
            
            SceneHandler otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
        private SceneHandler GetOtherPortal()
        {
            foreach (SceneHandler portal in FindObjectsOfType<SceneHandler>())
            {
                if (portal == this) continue;
                if (portal.destination != destination) continue;
                print(portal.name);
                return portal;
            }
            return null;
        }

        private void UpdatePlayer(SceneHandler otherPortal)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            print(player.name);
            print(otherPortal.spawnPoint.name +" " + otherPortal.spawnPoint.position);
            //unity first person controller defines position so unable to move by other means while components are enabled
            player.GetComponent<FirstPersonController>().enabled = false;
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = otherPortal.spawnPoint.position;

            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
