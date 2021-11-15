using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWeapon : MonoBehaviour
{
    int Distance;
    int Speed = 5;

    private GameObject Player;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag("Player").transform.localScale.x < 0)
        {
            Speed = -Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;
        Distance += 1;

        if (Distance <= 240)
        {
            transform.Translate(new Vector2(1, 0) * Speed * Time.deltaTime);
        }
        if (Distance > 240)
        {
            if (Vector3.Distance(transform.position, target.position) > 1f)
            {
                Speed = 5;
                transform.gameObject.tag = "ReturnLeft";
                MoveTowardsTarget();
                RotateTowardsTarget();
            }
        }
    }
    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            Distance = 240;
        }
    }
}
