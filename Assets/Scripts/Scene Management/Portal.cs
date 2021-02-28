using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace DungeonCrawl.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
                {
                    nextSceneIndex = 0;
                }
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

    }
}
