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
        private void SetPlayerActive()
        {
            int playerIndex = 0;
            foreach (Transform player in transform)
            {
                if (playerIndex == currentPlayer)
                {
                    player.gameObject.SetActive(true);
                }
                else
                {
                    player.gameObject.SetActive(false);
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