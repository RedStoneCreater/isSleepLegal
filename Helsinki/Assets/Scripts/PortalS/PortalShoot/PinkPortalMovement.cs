using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPortalMovement : MonoBehaviour
{
    [SerializeField]
    GameObject PinkPortal;
    [SerializeField]
    GameObject PinkPortalHorizontal;

    Vector2 m_mousePosPink;
    Vector2 m_PortalPinkPos;
    Vector2 m_PortalPinkRotation;
    [SerializeField]
    int m_Speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_mousePosPink = Input.mousePosition;
        m_PortalPinkPos = Camera.main.WorldToScreenPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.gameObject.tag = "ReturnPink";
            GetComponent<PinkPortalMovement>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<ReturnPinkMovement>().enabled = true;
        }
        m_PortalPinkRotation.x = m_mousePosPink.x - m_PortalPinkPos.x;
        m_PortalPinkRotation.y = m_mousePosPink.y - m_PortalPinkPos.y;

        float angle = Mathf.Atan2(m_PortalPinkRotation.y, m_PortalPinkRotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.Translate(Vector2.right * Time.deltaTime * m_Speed);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Floor")
        {
            Instantiate(PinkPortalHorizontal, transform.position, Quaternion.identity);
            transform.gameObject.tag = "ReturnPink";
            GetComponent<PinkPortalMovement>().enabled = false;
            GetComponent<ReturnPinkMovement>().enabled = true;
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Wall")
        {
            Instantiate(PinkPortal, transform.position, Quaternion.identity);
            transform.gameObject.tag = "ReturnPink";
            GetComponent<PinkPortalMovement>().enabled = false;
            GetComponent<ReturnPinkMovement>().enabled = true;
            Destroy(this.gameObject);
        }

    }
}
