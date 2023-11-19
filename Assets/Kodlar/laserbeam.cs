using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class laserbeam : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    public bool god = false;
    AudioSource sesKaynagi;

    private void Awake()
    {
       

    }
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        god = GameObject.Find("karakter").GetComponent<movement>().godmode;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(god == false)
        {
            Destroy(this.gameObject);
        }
        else
        {

        }
        
    }
}
