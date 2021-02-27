using Cinemachine;
using DungeonCrawl.Control;
using DungeonCrawl.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace DungeonCrawl.Core
{
    public class PlayerSwitcher : MonoBehaviour
    {
        [SerializeField] int currentPlayer = 0;

        Mover mover;

        Vector3 activePlayer;

        void Start()
        {
            SetPlayerActive();
            mover = GetComponent<Mover>();
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
            int playerControllerIndex = 0; 
            foreach (Transform playerController in transform)
            {                
                if (playerControllerIndex == currentPlayer)
                {
                    playerController.GetComponentInChildren<PlayerController>().enabled = true;
                    playerController.GetComponentInChildren<CinemachineVirtualCamera>().enabled = true;

                    //activePlayer = playerController.transform.position;

                }
                else
                {
                    // sets players inactive but doesn't move them. If manage to follow active player, also need to check navmeshagent.ifpathstale 
                    playerController.GetComponentInChildren<CinemachineVirtualCamera>().enabled = false;
                    playerController.GetComponentInChildren<PlayerController>().enabled = false;
                }
                playerControllerIndex++;
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