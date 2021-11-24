using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float WalkTimer = 5.0f;
    [SerializeField] float ShootTimer = 1.0f;
    [SerializeField] float BulletSpeed = 1.0f;

    public GameObject enemy;
    public GameObject bullet;
    public Transform player;
    public Transform barrelPos;
    public float sightRange;
    private float playerDist;

    private bool m_FacingRight = true;
    private bool canShoot;
    public float m_MoveSpeed = 15.0f;
    

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        Timer = WalkTimer;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        playerDist = Vector2.Distance(transform.position, player.position);
        if(playerDist <= sightRange)
        {
            if (player.position.x>transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            if(canShoot)
            {
                StartCoroutine(Shoot());
                
            }
            
        }


        Timer -= Time.deltaTime;


        if (Timer > 0)
        {
            if (m_FacingRight)
            {
                enemy.transform.Translate (new Vector2 (m_MoveSpeed,0)*Time.deltaTime);
                
            }

            if (!m_FacingRight)
            {
                enemy.transform.Translate(new Vector2(-m_MoveSpeed, 0) * Time.deltaTime);
                
            }


        }

        if (Timer <= 0)
        {
            
            Timer = WalkTimer;
            Flip();
        }


    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 _Scale = transform.localScale;
        _Scale.x *= -1;
        transform.localScale = _Scale;
        
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(ShootTimer);
        GameObject newBullet = Instantiate(bullet, barrelPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed * m_MoveSpeed * Time.fixedDeltaTime, 0f);
        canShoot = true;
    }


   
}
