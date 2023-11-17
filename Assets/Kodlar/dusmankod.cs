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
    bool s�kabilir = true;
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
        D�n();
        Alg�lama();
        AtesAlg�lama();
        if (enemydedected && atesdedected == false)
        {
            Hareket();
            agent.Resume();
        }
        else if (atesdedected && s�kabilir)
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
    void D�n()
    {
        Vector2 hedefYon = player.transform.position - transform.position;
        hedefYon.Normalize(); // Y�n vekt�r�n� normalize et

        // D��man�n rotasyonunu hedefe do�ru ayarla
        float aci = Mathf.Atan2(hedefYon.y, hedefYon.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, aci);
    }
    void AtesEt()
    {
        s�kabilir = false;
        StartCoroutine("s�kma");
        GameObject bullet = Instantiate(laserbeam, attackpoint.position, attackpoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(attackpoint.up * 40, ForceMode2D.Impulse);
    }
    void Alg�lama()
    {
        Collider2D[] dusmanlar = Physics2D.OverlapCircleAll(transform.position, dedectrange, karakterlayer);

        // Alg�lanan d��manlar� kontrol et
        if (dusmanlar.Length > 0)
        {
            // D��man alg�land�
            enemydedected = true;

            // �stedi�iniz i�lemleri burada yapabilirsiniz
            
        }
        else
        {
            // D��man alg�lanmad�
            enemydedected = false;
        }
    }
    void AtesAlg�lama()
    {
        Collider2D[] atesedilecek = Physics2D.OverlapCircleAll(transform.position, atesrange, karakterlayer);

        // Alg�lanan d��manlar� kontrol et
        if (atesedilecek.Length > 0)
        {
            // D��man alg�land�
            atesdedected = true;

            // �stedi�iniz i�lemleri burada yapabilirsiniz
            
        }
        else
        {
            // D��man alg�lanmad�
            atesdedected = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Editor i�inde alg�lama mesafesini g�ster
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dedectrange);
        Gizmos.DrawWireSphere(transform.position, atesrange);
    }

    IEnumerator s�kma()
    {
        yield return new WaitForSeconds(2);
        s�kabilir = true;
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
