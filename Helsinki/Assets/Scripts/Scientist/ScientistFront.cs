using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistFront : MonoBehaviour
{
    public GameObject scientist;
    public float moveSpeed = 0.5f;
    private bool m_FacingRight = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Flip();
        if (collision.gameObject.tag == "Player")
        {
            
            scientist.transform.Translate(new Vector2(moveSpeed * scientist.transform.localScale.x, 0) * Time.deltaTime);
        }
    }

    private void Flip()
    {
       
        m_FacingRight = !m_FacingRight;

        Vector3 _Scale = scientist.transform.localScale;
        _Scale.x *= -1;
        scientist.transform.localScale = _Scale;

    }
}
