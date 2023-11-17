using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmankod : MonoBehaviour
{
    public float dedectrange = 5f;
    public LayerMask karakterlayer;
    public bool enemydedected = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Algýlama();
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
            Debug.Log("Düþman Algýlandý: " + dusmanlar[0].gameObject.name);
        }
        else
        {
            // Düþman algýlanmadý
            enemydedected = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Editor içinde algýlama mesafesini göster
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dedectrange);
    }
}
