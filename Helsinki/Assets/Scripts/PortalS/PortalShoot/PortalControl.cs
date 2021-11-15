using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public static PortalControl portalControlInstance;

    [SerializeField]
    private GameObject RedPortal, PinkPortal;

    [SerializeField]
    private Transform RedPortalSpawnPoint, PinkPortalSpawnPoint;

    private Collider2D RedPortalCollider, PinkPortalCollider;

    [SerializeField]
    private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        portalControlInstance = this;
        RedPortalCollider = RedPortal.GetComponent<Collider2D>();
        PinkPortalCollider = PinkPortal.GetComponent<Collider2D>();
    }
    public void CreateClone(string whereToCreate)
    {
        if (whereToCreate == "atRed")
        {
            var instantiatedClone = Instantiate(clone, RedPortalSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
        if (whereToCreate == "atPink")
        {
            var instantiatedClone = Instantiate(clone, PinkPortalSpawnPoint.position, Quaternion.identity);
            instantiatedClone.gameObject.name = "Clone";
        }
    }

    public void DisableCollider(string colliderToDisable)
    {
        if(colliderToDisable == "Red")
        {
            RedPortalCollider.enabled = false;
        }
        if (colliderToDisable == "Pink")
        {
            PinkPortalCollider.enabled = false;
        }
    }

    public void EnableColliders()
    {
        RedPortalCollider.enabled = true;
        PinkPortalCollider.enabled = true;
    }
}
