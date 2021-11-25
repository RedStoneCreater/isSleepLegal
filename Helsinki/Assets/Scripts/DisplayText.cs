using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    [SerializeField]
    GameObject PopUpText;
    [SerializeField]
    bool CanReDisplay;
    int ReDisplay = 0;
    [SerializeField]
    bool IsDisplaying = false;
    [SerializeField]
    int TimeLimit = 5;

    int CountTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDisplaying == false)
        {
            PopUpText.GetComponent<Renderer>().enabled = false;
        }
        if (IsDisplaying == true && ReDisplay <= 0)
        {
            CountTime += 1;
            PopUpText.GetComponent<Renderer>().enabled = true;
        }
        if(CountTime >= TimeLimit * 60)
        {
            IsDisplaying = false;
            if (CanReDisplay == false)
            {
                ReDisplay += 1;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "PlayerObject")
        {
            Debug.Log("isDisplaying");
            IsDisplaying = true;
            CountTime = 0;
        }
    }
}
 