using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pot : MonoBehaviour
{
    public GameObject zehir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(zehir, this.transform.position, transform.rotation);
        Destroy(this.gameObject);


    }
    
}
