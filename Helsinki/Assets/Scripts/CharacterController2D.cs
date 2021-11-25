using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{

    [SerializeField] AudioSource JumpSound;
    public CharacterController m_Controller;
    public float m_Collider;

    [SerializeField] private float m_JumpSpeed = 20.0f;
    [Range(0, 1)] [SerializeField] private float m_CrouchMoveSpeed = 0.4f;
    [Range(0, 0.3f)] [SerializeField] private float m_SmooothMooove = 0.05f;
    [SerializeField] private bool m_AirControl = false;
    //[SerializeField] private float m_AirMobility = 0.2f;
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundChecking;
    [SerializeField] private Transform m_CeilingChecking;
    [SerializeField] private Collider2D m_CrouchDisableCollider;

    

    const float k_GroundRadius = 0.2f;
    private bool m_OnGround = false;
    const float k_CeilingRadius = 0.2f;
    private Rigidbody2D m_RigidBody2D;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity3 = Vector3.zero;
    public float m_MoveSpeed = 15.0f;


    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_WasCrouching;


    //called when script is being loaded
    private void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();


        
    }

    // Update is called once per fixed framerate frame
    void FixedUpdate()
    {
        bool wasGrounded = m_OnGround;
        m_OnGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundChecking.position, k_GroundRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_OnGround = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float _move, bool _crouching, bool _jumping)
    {
        /*if (!_crouching)
        {
            if (Physics2D.OverlapCircle(m_CeilingChecking.position, k_CeilingRadius, m_WhatIsGround))
            {
                _crouching = true;
            }
        }*/
        //on ground ------------------------------------------------------
        if (m_OnGround || m_AirControl)
        {
            if (_crouching)
            {
                if (!m_WasCrouching)
                {
                    m_WasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                _move *= m_CrouchMoveSpeed;

                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_WasCrouching)
                {
                    m_WasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector2(_move * m_MoveSpeed, m_RigidBody2D.velocity.y);
            m_RigidBody2D.velocity = Vector3.SmoothDamp(m_RigidBody2D.velocity, targetVelocity, ref m_Velocity3, m_SmooothMooove);

            if (_move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (_move < 0 && m_FacingRight)
            {
                Flip();
            }
 

            if (m_OnGround && _jumping)
            {
                m_OnGround = false;
                m_RigidBody2D.AddForce(new Vector2(0f, m_JumpSpeed));
                JumpSound.Play();
            }
        }
        
        
        





    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 _Scale = transform.localScale;
        _Scale.x *= -1;
        transform.localScale = _Scale;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //portal shenanigans and activate right/left box and disable normal head/foot collider and stuff
    }

}





