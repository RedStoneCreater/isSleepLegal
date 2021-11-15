using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject Portal_Obj;
    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count += 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Red")
        {
            if(Count >= 30)
            {
                Portal_Obj = GameObject.FindWithTag("Pink");
                transform.position = new Vector2(Portal_Obj.transform.position.x, Portal_Obj.transform.position.y);
                Count = 0;
            }
            
        }
        if (col.gameObject.tag == "Pink")
        {
            if (Count >= 30)
            {
                Portal_Obj = GameObject.FindWithTag("Red");
                transform.position = new Vector2(Portal_Obj.transform.position.x, Portal_Obj.transform.position.y);
                Count = 0;
            }
        }

    }
}
