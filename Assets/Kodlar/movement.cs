using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class movement : MonoBehaviour
{
    public GameObject laserbeam;
    public Transform attackpoint;
    Rigidbody2D rigid;
    Animator animator;
    public float speed = 5;
    public int enerji = 3;
    public Image pil;
    public bool godmode = false;
    GameObject[] enemy;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectsWithTag("enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Tekrar();
        }
        
        if (!animator.GetBool("die"))
        {
            pil.GetComponent<Animator>().SetInteger("sarj", enerji);
            if (enerji > 3)
            {
                enerji = 3;
            }
            Debug.Log(rigid.velocity);
            Hareket();
            if (godmode == false)
            {
                Attack();
            }
            if (godmode)
            {
                God();
               
            }
            RotateTowardsMouse();
            if (rigid.velocity != Vector2.zero)
            {
                animator.SetBool("movement", true);
            }
            else { animator.SetBool("movement", false); }

        }


    }

    void Hareket()
    {
        rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            rigid.velocity = Vector2.zero;
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && enerji >= 1)
        {
            animator.SetBool("attack", true);
            enerji -= 1;
            GameObject bullet = Instantiate(laserbeam, attackpoint.position, attackpoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackpoint.up * 26, ForceMode2D.Impulse);
        }
        else { animator.SetBool("attack", false); }
    }
    void God()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attack", true);
            GameObject bullet = Instantiate(laserbeam, attackpoint.position, attackpoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackpoint.up * 40, ForceMode2D.Impulse);
        }
    }
    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void Tekrar()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("laser") && godmode == false)
        {
            
            
            rigid.velocity = Vector3.zero;
            rigid.freezeRotation = true;
            animator.SetBool("die", true);
            
        }
        if (collision.collider.CompareTag("enerji"))
        {
            enerji += 1;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("kutu"))
        {
            godmode = true;
            pil.GetComponent<Animator>().SetBool("god", true);
            Destroy(collision.gameObject);
        }
    }
}
