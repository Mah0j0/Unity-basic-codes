using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    float horizontalMove;
    float verticalMove;
    [SerializeField]
    CharacterController player;

    [SerializeField]
    float playerSpeed;
    [SerializeField]
    float playerRunSpeed;

    float playerSpeedAux;
    //
    Vector3 playerInput;
    //
    //
    Camera cam;
    Vector3 camForward;
    Vector3 camRight;  

    Vector3 movePlayer;
    //
    //
    [SerializeField]
    float gravity = 9.8f;
    float fallSpeed;

    [SerializeField]
    float jumpForce;

    Animator animatorController;

    bool isRunnig = false;
    bool isWalking = false;
    bool isJamping = false;
    void Start()
    {
        player = GetComponent<CharacterController>();
        cam = Camera.main;
        playerSpeedAux = playerSpeed;
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if ((horizontalMove != 0 || verticalMove != 0) && !isRunnig) {
            animatorController.SetBool("Walk", true);
            isWalking = true;
        }
        else
        {
            animatorController.SetBool("Walk", false);
            isWalking = false;
        }

        if (!isRunnig && !isWalking && !isJamping)
        {
            animatorController.SetBool("Idle", true);
        }
        else {
            animatorController.SetBool("Idle", false);
        }
        //
        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);
        //
        CamDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward; 
        if(Input.GetButton("Fire3")){
            isRunnig = true;
            playerSpeed = playerRunSpeed;
            animatorController.SetBool("Run", true);
        }else{
            isRunnig = false;
            playerSpeed = playerSpeedAux;
            animatorController.SetBool("Run",false);
        }
        //
        movePlayer = movePlayer * playerSpeed;
        
        //player.Move(new Vector3(horizontalMove,0,verticalMove) * playerSpeed * Time.deltaTime);
        //player.Move(playerInput * playerSpeed * Time.deltaTime);
        player.transform.LookAt(player.transform.position + movePlayer);

        Gravity();
        Jump();

        player.Move(movePlayer * Time.deltaTime);
        //Debug.Log(player.velocity.y);
    }

    void CamDirection(){
        camForward = cam.transform.forward;
        camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    ////
    void Gravity(){
         if(player.isGrounded){
            fallSpeed = -gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }else{
            fallSpeed -= gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
    
    }
    ///
    void Jump(){
        if (player.isGrounded || player.velocity.y < 0.1f) {
            if (Input.GetButtonDown("Jump"))
            {
                fallSpeed = jumpForce;
                movePlayer.y = fallSpeed;
                isJamping = true;
                animatorController.SetBool("Jump", true);
            }
            else {
                isJamping = false;
                animatorController.SetBool("Jump", false);
            }

        }
    }
}
