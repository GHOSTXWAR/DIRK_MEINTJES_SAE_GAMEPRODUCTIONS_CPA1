using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAfterSpawn : MonoBehaviour
{
    public Transform playerTransform;
    public IEnumerator SpawnLocationProc(PlayerInput playerInput)
    {
        Debug.Log("Inside Coroutine, start");
        yield return new WaitForSeconds(0.5f);
        playerInput.GetComponentInChildren<ccPlayerMovement3D>().enabled = true;
        playerInput.GetComponentInChildren <PlayerActions>().enabled = true;
        Debug.Log("CoroutineWaited");
      
    }
    
}
