using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movement : MonoBehaviour
{
    public GameObject laserbeam;
    public Transform attackpoint;
    Rigidbody2D rigid;
    Animator animator;
    public float speed = 5;
    public float enerji = 3;
    
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enerji > 3)
        {
            enerji = 3;
        }
        Debug.Log(rigid.velocity);        
        Hareket();
        Attack();
        RotateTowardsMouse();
        if(rigid.velocity != Vector2.zero)
        {
            animator.SetBool("movement", true);
        }
        else { animator.SetBool("movement", false); }
        
    }

    void Hareket()
    {
        rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && enerji >= 1)
        {
            animator.SetBool("attack", true);
            enerji -= 1;
            GameObject bullet = Instantiate(laserbeam, attackpoint.position, attackpoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackpoint.up * 40, ForceMode2D.Impulse);
        }
        else { animator.SetBool("attack", false); }
    }
    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
