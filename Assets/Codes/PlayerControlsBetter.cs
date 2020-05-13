using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsBetter : MonoBehaviour
{
    
    private Rigidbody2D rigitysRuumis;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;

    public float checkRadius;

    public LayerMask whatIsGround;

    private float jumpTimerCounter;
    public float jumpTime;
    private bool isJumping;

    void Start()
    {
        rigitysRuumis = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
        rigitysRuumis.velocity = new Vector2(moveInput * speed, rigitysRuumis.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0 ){
            transform.eulerAngles = new Vector3(0,0,0);
        } else if(moveInput < 0){
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
            jumpTimerCounter = jumpTime;
            rigitysRuumis.velocity = Vector2.up * jumpForce;

        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true){

            if(jumpTimerCounter > 0){
                rigitysRuumis.velocity = Vector2.up * jumpForce; //douple jump
                jumpTimerCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }

            }
            if(Input.GetKeyUp(KeyCode.Space)){ //jump time counter is now zero
                isJumping = false;

            }
            
        }
    }
