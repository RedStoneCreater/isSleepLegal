using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject m_Target;
    public float m_Speed;
    Rigidbody2D m_BulletRB;
    PlayerManager m_PlayerManager;

     void Start()
    {
        m_BulletRB = GetComponent<Rigidbody2D>();
        m_Target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDirection = (m_Target.transform.position - transform.position).normalized * m_Speed;
        m_BulletRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(this.gameObject, 1);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<HealthBar>().slider.value -= 15;
            Destroy(gameObject);
        }
    }
}
