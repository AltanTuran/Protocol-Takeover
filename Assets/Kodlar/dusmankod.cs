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
        Alg�lama();
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
            Debug.Log("D��man Alg�land�: " + dusmanlar[0].gameObject.name);
        }
        else
        {
            // D��man alg�lanmad�
            enemydedected = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Editor i�inde alg�lama mesafesini g�ster
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dedectrange);
    }
}
