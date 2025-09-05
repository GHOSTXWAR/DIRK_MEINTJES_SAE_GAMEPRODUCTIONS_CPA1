using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ccPlayerMovement3D : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float sprintMagnitude = 2.0f;
    private float gravityValue = -9.8f;
    private float initialPlayerSpeed = 0;
    

    private InputActionAsset inputActions;
    private InputActionMap player;
    private InputAction move;
    private InputAction sprint;
    private InputAction jump;
    

    public SPSystem staminaSys;
    public Transform playerHead;

    private Vector3 v3playerHeadPosition;

    private bool DoubleJumpReady = false,canDoubleJump = false;

    private float CoyoteTime;
    [SerializeField] private float CoyoteTimeMax;


    private void Awake()
    {
        inputActions = this.GetComponentInChildren<PlayerInput>().actions;
        player = inputActions.FindActionMap("Player");
        
        initialPlayerSpeed = playerSpeed;
        v3playerHeadPosition = playerHead.position;
       
    }
    private void OnEnable()
    {
        player.Enable();
        jump = player.FindAction("Jump");
        sprint = player.FindAction("Sprint");
        move = player.FindAction("Move");
       
    }

    private void OnDisable()
    {
        player.Disable();
    }

    public bool IsGrounded()
    {

        return CoyoteTime < CoyoteTimeMax;
    }

    public void CoyoteControl()
    {
        if (controller.isGrounded)
        {
            CoyoteTime = 0;
        }
        else { CoyoteTime += Time.deltaTime; }
    }
    void PlayerJump()
    {
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue );
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //<jump>
        if ((jump.ReadValue<float>() == 1) && (IsGrounded()))
        {
            canDoubleJump = true;
            PlayerJump();
        }
        if (canDoubleJump && jump.ReadValue<float>() == 0 && !IsGrounded())
        {
            DoubleJumpReady = true;
        }
        if ((jump.ReadValue<float>() == 1) && DoubleJumpReady)
        {
            PlayerJump();
            DoubleJumpReady = false;
            canDoubleJump = false;
        }
        //</jump>

        //<sprint>
        if (((sprint.ReadValue<float>() == 1) && staminaSys.SP > 0 && !staminaSys.isSPCooldown) && playerSpeed != (initialPlayerSpeed * sprintMagnitude))
        {
            playerSpeed *= sprintMagnitude;
            staminaSys.isSprinting = true;
        }
        else if ((playerSpeed != initialPlayerSpeed && (sprint.ReadValue<float>() == 0)) || staminaSys.SP <= 0)
        {
            playerSpeed = initialPlayerSpeed;
            staminaSys.isSprinting = false;                    
        }
        

    }
    void Update()
    {
        CoyoteControl();
        groundedPlayer = IsGrounded();
        if (groundedPlayer && playerVelocity.y < 0) {
            playerVelocity.y = 0f;
        }
        Vector3 v3move = new (move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);
        v3move = Vector3.ClampMagnitude(v3move, 1f); // fix for fast diagonal movement
        
        
       
        //gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

       Vector3 finalMove = transform.TransformDirection((v3move * playerSpeed) + (playerVelocity.y * Vector3.up));
       controller.Move(finalMove * Time.deltaTime);

      /*  if (groundedPlayer && (finalMove.x != 0 || finalMove.z != 0)) 
        {
            SoundManager.Instance.PlayFootstepSound();
        }
        else
        {
            SoundManager.Instance.StopFootstepSound();
        }*/

        
        

    }
}
