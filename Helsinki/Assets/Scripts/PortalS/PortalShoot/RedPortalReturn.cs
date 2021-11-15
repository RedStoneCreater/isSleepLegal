using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPortalReturn : MonoBehaviour
{
    [SerializeField]
    GameObject RedPortalShoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RedPortalShoot.transform.gameObject.tag = "ReturnRed";
            RedPortalShoot.GetComponent<RedPortalMovement>().enabled = false;
            RedPortalShoot.GetComponent<BoxCollider2D>().enabled = false;
            RedPortalShoot.GetComponent<ReturnRedMovement>().enabled = true;
            Instantiate(RedPortalShoot, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
