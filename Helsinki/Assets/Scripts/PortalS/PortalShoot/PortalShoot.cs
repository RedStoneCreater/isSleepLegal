using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShoot : MonoBehaviour
{
    [SerializeField] AudioSource OnPortalShootSound;
    [SerializeField] AudioSource OnShootSound;
    
    
    [SerializeField] GameObject RedPortalShoot;
    [SerializeField] GameObject PinkPortalShoot;


    [SerializeField] GameObject LeftFirePortal;
    [SerializeField] GameObject RightFirePortal;


    [SerializeField]
    GameObject RedPortalCount;
    [SerializeField]
    GameObject PinkPortalCount;


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
                OnPortalShootSound.Play();

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
                OnPortalShootSound.Play();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (RedPortalOut == false)
            {
                RedPortalOut = true;
                Instantiate(LeftFirePortal, transform.position, Quaternion.identity);
                OnShootSound.Play();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (PinkPortalOut == false)
            {
                PinkPortalOut = true;
                Instantiate(RightFirePortal, transform.position, Quaternion.identity);
                OnShootSound.Play();
            }
        }
        if (RedPortalOut == false)
        {
            RedPortalCount.GetComponent<Renderer>().enabled = true;
            RedPortalCount.GetComponent<FollowPlayer>().enabled = true;
        }
        if (PinkPortalOut == false)
        {
            PinkPortalCount.GetComponent<Renderer>().enabled = true;
            PinkPortalCount.GetComponent<FollowPlayer>().enabled = true;
        }
        if (RedPortalOut == true)
        {
            RedPortalCount.GetComponent<Renderer>().enabled = false;
            RedPortalCount.GetComponent<FollowPlayer>().enabled = false;
            RedPortalCount.transform.position = new Vector2(transform.position.x - 0.24f, transform.position.y + 0.116f);
        }
        if (PinkPortalOut == true)
        {
            PinkPortalCount.GetComponent<Renderer>().enabled = false;
            PinkPortalCount.GetComponent<FollowPlayer>().enabled = false;
            PinkPortalCount.transform.position = new Vector2(transform.position.x + 0.199f, transform.position.y + 0.214f);
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
