using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    int count;
    int randomNum;
    float speed =  0.25f;
    bool GoUp;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        GoUp = false;
    }

    // Update is called once per frame


    private void Update()
    {
        count += 1;

        if (GoUp == true)
        {
            if (count <= randomNum)
            {
                transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
            }
            if (count > randomNum)
            {
                GoUp = false;
                count = 0;
                RandomCount();
            }
        }
        if (GoUp == false)
        {
            if (count <= randomNum)
            {
                transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
            }
            if (count > randomNum)
            {
                GoUp = true;
                count = 0;
            }
        }

    }
    void RandomCount()
    {
        randomNum = Random.Range(60, 180);
    }
}
