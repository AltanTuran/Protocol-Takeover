using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class dusmankod : MonoBehaviour
{
    public float dedectrange = 5f;
    public GameObject player;
    public GameObject enerji;
    public GameObject laserbeam;
    public Transform attackpoint;
    public LayerMask karakterlayer;
    public bool enemydedected = false;
    public bool atesdedected = false;
    Rigidbody2D rigidbody2;
    NavMeshAgent agent;
    public float atesrange;
    bool sýkabilir = true;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();   
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Dön();
        Algýlama();
        AtesAlgýlama();
        if (enemydedected && atesdedected == false)
        {
            Hareket();
            agent.Resume();
        }
        else if (atesdedected && sýkabilir)
        {
            AtesEt();
            agent.Stop();

        }
        else { agent.Stop(); }
    }

    void Hareket()
    {
        
        agent.SetDestination(player.transform.position);
        
    }
    void Dön()
    {
        Vector2 hedefYon = player.transform.position - transform.position;
        hedefYon.Normalize(); // Yön vektörünü normalize et

        // Düþmanýn rotasyonunu hedefe doðru ayarla
        float aci = Mathf.Atan2(hedefYon.y, hedefYon.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, aci);
    }
    void AtesEt()
    {
        sýkabilir = false;
        StartCoroutine("sýkma");
        GameObject bullet = Instantiate(laserbeam, attackpoint.position, attackpoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(attackpoint.up * 40, ForceMode2D.Impulse);
    }
    void Algýlama()
    {
        Collider2D[] dusmanlar = Physics2D.OverlapCircleAll(transform.position, dedectrange, karakterlayer);

        // Algýlanan düþmanlarý kontrol et
        if (dusmanlar.Length > 0)
        {
            // Düþman algýlandý
            enemydedected = true;

            // Ýstediðiniz iþlemleri burada yapabilirsiniz
            
        }
        else
        {
            // Düþman algýlanmadý
            enemydedected = false;
        }
    }
    void AtesAlgýlama()
    {
        Collider2D[] atesedilecek = Physics2D.OverlapCircleAll(transform.position, atesrange, karakterlayer);

        // Algýlanan düþmanlarý kontrol et
        if (atesedilecek.Length > 0)
        {
            // Düþman algýlandý
            atesdedected = true;

            // Ýstediðiniz iþlemleri burada yapabilirsiniz
            
        }
        else
        {
            // Düþman algýlanmadý
            atesdedected = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Editor içinde algýlama mesafesini göster
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dedectrange);
        Gizmos.DrawWireSphere(transform.position, atesrange);
    }

    IEnumerator sýkma()
    {
        yield return new WaitForSeconds(2);
        sýkabilir = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("laser"))
        {
            Instantiate(enerji, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
    }
}
