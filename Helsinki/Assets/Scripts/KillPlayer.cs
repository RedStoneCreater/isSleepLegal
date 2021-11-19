using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject killCam;
    public GameObject player;
    public GameObject mCam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if(collision.gameObject.tag == "Player" )
        {
            mCam.GetComponent<AudioListener>().enabled = false;
            Destroy(collision.gameObject);
            Instantiate(killCam, this.transform);
        }
    }
}
