using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraefekt : MonoBehaviour
{
    movement mov;
    float mod = 0.1f;
    float zval = 0f;
    void Start()
    {
        mov = GameObject.Find("karakter").GetComponent<movement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (mov.GetComponent<Animator>().GetBool("movement"))
        {
            Vector3 rot = new Vector3(0, 0, zval);
            this.transform.eulerAngles = rot;

            zval += mod;

            if(transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z <= 10.0f)
            {
                mod = -0.01f;
            }
            if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.01f;
            }
        }
    }
}
