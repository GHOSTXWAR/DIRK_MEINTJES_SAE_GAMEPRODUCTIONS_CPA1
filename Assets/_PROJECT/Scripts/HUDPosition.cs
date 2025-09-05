using UnityEngine;
using UnityEngine.InputSystem;

public class HUDPosition : MonoBehaviour
{
    public GameObject HUDParent;
    private void Awake()
    {
        if (GetComponentInChildren<PlayerInput>().user.index == 1)
        {
            HUDParent.transform.position = new Vector3 (1695, 145, 0);
        }
    }
}
