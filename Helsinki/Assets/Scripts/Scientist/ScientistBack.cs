using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistBack : MonoBehaviour
{
    public GameObject scientist;
    public float moveSpeed = 0.5f;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scientist.transform.Translate(new Vector2(moveSpeed * scientist.transform.localScale.x, 0) * Time.deltaTime);
        }
    }
    private void Update()
    {
        
    }
}
