using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPortalReturn : MonoBehaviour
{
    [SerializeField]
    GameObject PinkPortalShoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PinkPortalShoot.transform.gameObject.tag = "ReturnPink";
            PinkPortalShoot.GetComponent<PinkPortalMovement>().enabled = false;
            PinkPortalShoot.GetComponent<BoxCollider2D>().enabled = false;
            PinkPortalShoot.GetComponent<ReturnPinkMovement>().enabled = true;
            Instantiate(PinkPortalShoot, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}