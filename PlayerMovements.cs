using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
   private  float xOffset;
   [SerializeField] private float tracklimit = 1f;
   [SerializeField] private float moveSpeed = 5f;
   [SerializeField] private float horizontalSpeed = 1f;
   [SerializeField] private float jumpForce = 5f;

   private bool isGrounded = false;
   [SerializeField] private float groundCheckRange;
   [SerializeField] private bool canRun;
   private bool isAlive;

   public Rigidbody rb;
   private Animator playerAnimator;
   private float hortizontalInput;

   [SerializeField] private AudioSource JumpSoundEffect;
   [SerializeField] private AudioSource deathSoundEffect;

    void Start()
    {
        xOffset = transform.position.x;
        playerAnimator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody>();
        isAlive = true;
    }
    void Update()
    {
        if(canRun){
            PlayerMovement();
        }
        CheckIfGrounded();
        if(isAlive)
            GetInputs();
    }
    private void PlayerMovement()
    {
        Vector3 targetPos = transform.position;
        targetPos.z =targetPos.z +2f;
        targetPos.x = xOffset *horizontalSpeed;
        transform.position = Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
    }

    private void GetInputs()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xOffset = xOffset - tracklimit;
            playerAnimator.Play("Jump");
            JumpSoundEffect.Play();
        }
        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            xOffset = xOffset + tracklimit;
            playerAnimator.Play("Jump");
            JumpSoundEffect.Play();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
           
            Jump();
        }
        xOffset = Mathf.Clamp(xOffset,-tracklimit,+tracklimit);
        
    }

    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = Vector3.up * jumpForce;
            playerAnimator.Play("JumpHigh");
            JumpSoundEffect.Play();
        }
    }
    private void CheckIfGrounded()
    {
        RaycastHit hit;
        Vector3 groundCheckPos = transform.position;
        groundCheckPos.y = groundCheckPos.y +1f;

        if(Physics.Raycast(groundCheckPos, -Vector3.up,out hit, groundCheckRange))
        {
            if(hit.transform.gameObject.CompareTag("Ground"));
                isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }   
    }
    public void SetRunningState(bool state)
    {
        canRun = state;
    }
    public void OnPlayerHit()
    {
        isAlive = false;
        SetRunningState(false);
        playerAnimator.Play("FallingToDeath");
        deathSoundEffect.Play();
    }
}
