using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            //create dead bohde
        }
    }
}
