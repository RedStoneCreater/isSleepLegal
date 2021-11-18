using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPortalMovement : MonoBehaviour
{
    [SerializeField]
    GameObject RedPortal;
    [SerializeField]
    GameObject RedPortalHorizontal;

    Vector2 m_mousePosRed;
    Vector2 m_PortalRedPos;
    Vector2 m_PortalRedRotation;
    [SerializeField]
    int m_Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_mousePosRed = Input.mousePosition;
        m_PortalRedPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        

        m_PortalRedRotation.x = m_mousePosRed.x - m_PortalRedPos.x;
        m_PortalRedRotation.y = m_mousePosRed.y - m_PortalRedPos.y;

        float angle = Mathf.Atan2(m_PortalRedRotation.y, m_PortalRedRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(Vector2.right * Time.deltaTime * m_Speed);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            Instantiate(RedPortalHorizontal, transform.position, Quaternion.identity);
            transform.gameObject.tag = "Respawn";
            GetComponent<RedPortalMovement>().enabled = false;
            GetComponent<ReturnRedMovement>().enabled = true;
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Wall")
        {
            Instantiate(RedPortal, transform.position, Quaternion.identity);
            transform.gameObject.tag = "Respawn";
            GetComponent<RedPortalMovement>().enabled = false;
            GetComponent<ReturnRedMovement>().enabled = true;
            Destroy(this.gameObject);
        }

    }
}
