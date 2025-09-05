using UnityEngine;
public class PlayerRotate : MonoBehaviour
{
    public Camera mainCamera;
    private void Start()

    {
        // Find the main camera in the scene
       
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        // Rotate the player towards the camera every frame

        RotatePlayerTowardsCamera();
    }
    private void RotatePlayerTowardsCamera()
    {
       
        if (mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;

            cameraForward.y = 0f; // Ignore the y-axis rotation
            if (cameraForward != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(cameraForward);

                transform.rotation = newRotation;
            }

        }

    }
    private void OnDisable()
    {
        Cursor.lockState= CursorLockMode.None;
        Cursor.visible = true;
    }


}
