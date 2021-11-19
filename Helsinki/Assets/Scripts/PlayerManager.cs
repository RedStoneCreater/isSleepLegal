using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coincount;
    public float PlayerHealth;

    public bool PickUpItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "AccessCoin":
                coincount++;
                return true;
                

            default:
                Debug.LogWarning($"WARNING: No Handler implemented for tag {obj.tag}.");
                return false;

            case "HealthOrb":
                PlayerHealth += 10;
                return true;
        }
        
    }
}
