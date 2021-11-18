using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnRedMovement : MonoBehaviour
{
    private GameObject Player;
    private Transform target;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void Update()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;

        if (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void MoveTowardsTarget()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 0f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
