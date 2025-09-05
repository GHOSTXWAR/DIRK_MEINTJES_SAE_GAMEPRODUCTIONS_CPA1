using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class PlayerSpawn : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public int playerCount = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = SpawnPoints[playerCount].position;
        StartCoroutine(playerInput.GetComponentInChildren<MovementAfterSpawn>().SpawnLocationProc(playerInput));

        playerCount++;
      
    }
}
