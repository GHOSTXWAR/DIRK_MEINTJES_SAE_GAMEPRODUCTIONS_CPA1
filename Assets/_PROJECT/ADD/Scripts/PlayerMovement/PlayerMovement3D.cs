using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement3D : MonoBehaviour
{
    public InputSystem_Actions playerMovement;
    private InputAction move;
    private InputAction sprint;
    private InputAction jump;

    public Transform orientation;
    private Vector3 moveDirection;
    private Vector2 v2Input;
    private Rigidbody rb;
    [Range(0f,2f)]
    public float jumpHeight = 1;
    private float jumpVelocity = 30;

    public float speed = 10.5f;
    //sprint intensity changes speed by a multiple
    public float sprintIntensity = 3;
    private bool isGrounded = false;
    private bool canDoubleJump = false;
    private bool DoubleJumpReady = false;
    private bool isJumping = false;

    private float rbWalkLinearDamp, rbSprintLinearDamp, walkSpeed, sprintSpeed;
    private void Awake()
    {
        playerMovement = new InputSystem_Actions();
        
    }
    private void OnEnable()
    {
        jump = playerMovement.Player.Jump;
        sprint = playerMovement.Player.Sprint;
        move = playerMovement.Player.Move;
        move.Enable();
        sprint.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        sprint.Disable();
        jump.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rbWalkLinearDamp = rb.linearDamping;
        walkSpeed = speed;
        sprintSpeed = sprintIntensity * walkSpeed;
        rbSprintLinearDamp = rb.linearDamping * sprintIntensity;
    }
    private void Update()
    {
        MoveInput();
    }
    private void MoveInput()
    {
        v2Input = move.ReadValue<Vector2>();
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * v2Input.y + orientation.right * v2Input.x;
        rb.AddForce(10f * speed * moveDirection.normalized, ForceMode.Force);
       
    }
    private void PlayerSprint()
    {
        speed = sprintSpeed;
        rb.linearDamping = rbSprintLinearDamp;
    }
    private void PlayerWalk()
    {
        speed = walkSpeed;
        rb.linearDamping = rbWalkLinearDamp;
    }

    private void PlayerJump()
    {
        //
        
        rb.AddForce(0,jumpHeight * jumpVelocity,0,ForceMode.Impulse);
    }
    //Activates when rigidbody collides
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canDoubleJump = true;
            DoubleJumpReady = false;
            isJumping = false;
        }
    }
    //Activates when rigidbody leaves collision
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            isJumping = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        if ((sprint.ReadValue<float>() == 1) && (speed != sprintSpeed || rb.linearDamping != rbSprintLinearDamp)) PlayerSprint();
        else if ((sprint.ReadValue<float>() == 0) && (speed == sprintSpeed || rb.linearDamping == rbSprintLinearDamp)) PlayerWalk();
        
        //jumpcode
        if ((jump.ReadValue<float>() == 1) && (isGrounded))
        {
                PlayerJump();   
        }
        if (canDoubleJump && jump.ReadValue<float>() == 0 && isJumping)
        {
            DoubleJumpReady = true;
        }
        if ((jump.ReadValue<float>() == 1) && DoubleJumpReady)
        {
            PlayerJump();
            DoubleJumpReady = false;
            canDoubleJump = false;
        }
    }
    
}
