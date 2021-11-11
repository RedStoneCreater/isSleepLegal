using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float HorMove = 0f;
    public float moveSpeed = 40.0f;
    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorMove = Input.GetAxis("Horizontal") * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(HorMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        crouch = false;
    }
}
