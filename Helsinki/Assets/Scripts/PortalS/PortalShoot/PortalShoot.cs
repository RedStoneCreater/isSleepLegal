﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    [SerializeField]
    GameObject RedPortalShoot;
    [SerializeField]
    GameObject PinkPortalShoot;

    [SerializeField]
    GameObject LeftFirePortal;
    [SerializeField]
    GameObject RightFirePortal;


    public bool RedPortalOut = false;
    public bool PinkPortalOut = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (RedPortalOut == false)
            {
                RedPortalOut = true;
                RedPortalShoot.transform.gameObject.tag = "Respawn";
                RedPortalShoot.GetComponent<BoxCollider2D>().enabled = true;
                Instantiate(RedPortalShoot, transform.position, Quaternion.identity);


            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PinkPortalOut == false)
            {
                PinkPortalOut = true;
                PinkPortalShoot.transform.gameObject.tag = "Respawn";
                PinkPortalShoot.GetComponent<BoxCollider2D>().enabled = true;
                Instantiate(PinkPortalShoot, transform.position, Quaternion.identity);

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (RedPortalOut == false)
            {
                RedPortalOut = true;
                Instantiate(LeftFirePortal, transform.position, Quaternion.identity);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (PinkPortalOut == false)
            {
                PinkPortalOut = true;
                Instantiate(RightFirePortal, transform.position, Quaternion.identity);
            }
        }


    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ReturnPink")
        {

            PinkPortalOut = false;
            PinkPortalShoot.GetComponent<PinkPortalMovement>().enabled = true;
            PinkPortalShoot.GetComponent<ReturnPinkMovement>().enabled = false;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "ReturnRed")
        {

            RedPortalOut = false;
            RedPortalShoot.GetComponent<RedPortalMovement>().enabled = true;
            RedPortalShoot.GetComponent<ReturnRedMovement>().enabled = false;
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "ReturnLeft")
        {
            RedPortalOut = false;
            collider.transform.gameObject.tag = "FireLeft";
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "ReturnRight")
        {
            PinkPortalOut = false;
            collider.transform.gameObject.tag = "FireRight";
            Destroy(collider.gameObject);
        }
    }
}
