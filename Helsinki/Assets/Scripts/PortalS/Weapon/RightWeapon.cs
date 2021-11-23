using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWeapon : MonoBehaviour
{
    int Distance;
    int Speed = 5;
    Vector2 m_mousePosRed;
    Vector2 m_PortalRedPos;
    Vector2 m_PortalRedRotation;

    private GameObject Player;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player").transform.localScale.x < 0)
        {
            transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        m_mousePosRed = Input.mousePosition;
        m_PortalRedPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        Distance += 1;

        if (Distance <= 200)
        {
            m_PortalRedRotation.x = m_mousePosRed.x - m_PortalRedPos.x;
            m_PortalRedRotation.y = m_mousePosRed.y - m_PortalRedPos.y;

            float angle = Mathf.Atan2(m_PortalRedRotation.y, m_PortalRedRotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        if (Distance > 200)
        {
            if (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                Speed = 5;
                transform.gameObject.tag = "ReturnRight";
                MoveTowardsTarget();
                RotateTowardsTarget();
            }
        }
    }
    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 0f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall" || collider.gameObject.tag == "Enemy")
        {
            Distance = 240;
        }
    }
}
