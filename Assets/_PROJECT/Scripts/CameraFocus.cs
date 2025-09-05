using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraFocus : MonoBehaviour
{
    public CinemachineBrain brain;
    public ICinemachineCamera CamA;
    public ICinemachineCamera CamB;

    public CinemachineInputAxisController InputAxisController;
    public PlayerInput PlayerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CamA = GetComponent<CinemachineCamera>();
        CamB = GetComponent<CinemachineCamera>();

        int layer = 1;
        int priority = 1;
        float weight = 1f;
        float blendTime = 0f;
        brain.SetCameraOverride(layer, priority, CamA,CamB,weight, blendTime);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
