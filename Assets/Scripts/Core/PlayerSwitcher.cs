using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonCrawl.Core
{
    public class PlayerSwitcher : MonoBehaviour
    {
        [SerializeField] int currentPlayer = 0;


        void Start()
        {
            SetPlayerActive();

        }

        void Update()
        {
            int previousPlayer = currentPlayer;

            ProcessKeyInput();
            ProcessScrollWheel();

            if (previousPlayer != currentPlayer)
            {
                SetPlayerActive();
            }
        }
        private void SetPlayerActive() //todo set playercontroller active
        {
            int playerIndex = 0; //playercontrollerindex
            foreach (Transform player in transform)  // for each PlayerController playerController in playableCharacters - do this
            {
                if (playerIndex == currentPlayer)
                {
                    player.gameObject.SetActive(true); // playercontroller.getcomponent of type Playercontroller. enabled = true
                }
                else
                {
                    player.gameObject.SetActive(false); // playercontroller.getcomponent of type Playercontroller. enabled = false
                    //and follow the currentPlayer
                    //if navmeshagent.ispathstale = true, then wait // also open the bool up to the whole class
                }
                playerIndex++;
            }
        }
        private void ProcessKeyInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentPlayer = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentPlayer = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentPlayer = 2;
            }
        }
        private void ProcessScrollWheel()
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (currentPlayer >= transform.childCount - 1)
                {
                    currentPlayer = 0;
                }
                else
                {
                    currentPlayer++;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (currentPlayer <= 0)
                {
                    currentPlayer = transform.childCount - 1;
                }
                else
                {
                    currentPlayer--;
                }
            }
        }
    }

}