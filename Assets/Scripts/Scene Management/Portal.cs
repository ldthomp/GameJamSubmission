using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using DungeonCrawl.Core;

namespace DungeonCrawl.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] Canvas winScreen;
        int nextSceneIndex;
        int currentSceneIndex;
        [SerializeField] Health player1;
        [SerializeField] Health player2;
        [SerializeField] Health player3;


        private void Update()
        {
            if (player1.IsDead() == true && player2.IsDead() == true && player3.IsDead() == true)
            {
                SceneManager.LoadScene(currentSceneIndex);
            }    
        }
        private void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                
                nextSceneIndex = currentSceneIndex + 1;
                if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                {
                    StartCoroutine(WinScreen());
                    nextSceneIndex = 0;
                }
                else
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                
            }
            IEnumerator WinScreen ()
            {
                print("you win!");
                winScreen.gameObject.SetActive(true);
                yield return new WaitForSeconds(5f);
                winScreen.gameObject.SetActive(false);
                SceneManager.LoadScene(nextSceneIndex);

            }
           
        }

    }
}
