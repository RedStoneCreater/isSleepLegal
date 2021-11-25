using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] 
    float WalkTimer = 5.0f;

    public GameObject enemy;
    private bool m_FacingRight = true;
    public float m_MoveSpeed = 4.0f;

    public float m_SightRange;
    public float m_ShootRange;

    public float m_FireRate = 1f;
    private float m_NextShot;

    public GameObject m_Bullet;
    public GameObject m_BulletParent;

    private Transform m_Player;

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = WalkTimer;
        // Locate Player Position (Transform Value)
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Timer
        Timer -= Time.deltaTime;

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
        // Seeking - Calculate Distance from player to start walking towards
        float distanceFromPlayer = Vector2.Distance(m_Player.position, transform.position);
        if (distanceFromPlayer < m_SightRange && distanceFromPlayer > m_ShootRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, m_Player.position, m_MoveSpeed * Time.deltaTime);
        }
        // Shooting - Calculate Distance from player to start shooting 
        else if ( distanceFromPlayer <= m_ShootRange && m_NextShot < Time.time)
        {
            Instantiate(m_Bullet, m_BulletParent.transform.position, Quaternion.identity);
            m_NextShot = Time.time + m_FireRate;
        }
    }
    // Flip Function 
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 _Scale = transform.localScale;
        _Scale.x *= -1;
        transform.localScale = _Scale;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_SightRange);
        Gizmos.DrawWireSphere(transform.position, m_ShootRange);
    }
}

