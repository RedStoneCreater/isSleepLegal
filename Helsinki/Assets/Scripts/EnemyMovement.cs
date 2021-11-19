using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float WalkTimer = 5.0f;


    public GameObject enemy;
    private bool m_FacingRight = true;
    public float m_MoveSpeed = 15.0f;
    

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = WalkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer -= Time.deltaTime;

        float x = 0f;

        if (Timer > 0)
        {
            if (m_FacingRight)
            {
                enemy.transform.Translate (new Vector2 (m_MoveSpeed,0)*Time.deltaTime);
                
            }

            if (!m_FacingRight)
            {
                enemy.transform.Translate(new Vector2(-m_MoveSpeed, 0) * Time.deltaTime);
                
            }


        }

        if (Timer <= 0)
        {
            
            Timer = WalkTimer;
            Flip();
        }


    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 _Scale = transform.localScale;
        _Scale.x *= -1;
        transform.localScale = _Scale;
        
    }


   
}
