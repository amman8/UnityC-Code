using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYMOVE : MonoBehaviour
{

    public CharacterController controller;
    public float walk = 2f;
    public float speed;
    public float gravity =-9.8f;
    Vector3 velocity;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGround;
    public float jumpheight = 2f;
    public Animator player;
    public float sprint=4f;
    public AudioSource run;
    public AudioSource Breath;
    public bool ifrunning=false;
    public bool forsound = false;
    public bool open = false;
    public bool isopen = false;
    public Maindoor md;
    public mouse Mouse;
    public bool iscrouching = false;
    public float crouchheight = 1f;
    public bool itstrue = true;

    private void Start()
    {
        md = GameObject.FindObjectOfType<Maindoor>();
        Mouse = GameObject.FindObjectOfType<mouse>();
    }

    void Update()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGround && velocity.y<0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (controller.isGrounded && Input.GetKey("left shift")|| Input.GetKey("right shift"))
        {   
            if(iscrouching == false)
            {
                forsound = true;
                speed = sprint;             //speed = sprint is Heare........................
                player.SetBool("run", forsound);
                if (ifrunning == false)
                {
                    ifrunning = true;
                    Invoke("Latefunction", 3f);
                }
            }
        }

        else
        {
            speed = walk;               //speed = walk is Heare........................
            player.SetBool("run", false);
            ifrunning = false;
        }

        if (Input.GetKeyDown("f"))      //Gate Open Input is Heare.......................
        {
            if (md.check == true)
            {
                isopen = true;
            }
            GateOpening();
            Invoke("Gateopen", 4f);
        }

        if (Input.GetKey("c"))
        {
            player.SetBool("Crouch", true);
            controller.height = crouchheight;
            iscrouching = true;
        }
        else
        {
            controller.height = 1.77f;
            player.SetBool("Crouch", false);
            iscrouching = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            player.SetTrigger("jump");
        }

       velocity.y += gravity * Time.deltaTime;

       controller.Move(velocity * Time.deltaTime);

    }

    private void Run ()
    {
        run.Play();
    }

    void Latefunction()
    {
        if (ifrunning == true)
        {
            ifrunning = false;
            if (ifrunning==false)
            {
                Breath.Play();
                ifrunning = true;
            }
        }
    }

    public void Gateopen()
    {   
        if (itstrue == true)
        {
            open = false;
            player.SetBool("open", open);
            walk = 2f;
            sprint = 4f;
            Mouse.mouseSensity = 130f;
        }
        
    }

    public void GateOpening()
    {
        Mouse.mouseSensity = 0f;
        open = true;
        player.SetBool("open", open);
        walk = 0f;
        sprint = 0f;
    }
}