using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistMovement : MonoBehaviour
{
    //public GameObject front;
    //public GameObject back;
    public GameObject scientist;
    public float moveSpeed;
    public bool FacingRight = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void Run()
    {
        if (FacingRight)
        {
            scientist.transform.Translate(new Vector2(moveSpeed * scientist.transform.localScale.x, 0) * Time.deltaTime);

        }

        if (!FacingRight)
        {
            scientist.transform.Translate(new Vector2(-moveSpeed, 0) * Time.deltaTime);

        }
    }
}
