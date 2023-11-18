using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraefekt : MonoBehaviour
{
    movement mov;
    float mod = 0.1f;
    float zval = 0f;
    CinemachineVirtualCamera cam;
    GameObject karakter;
    GameObject bakmanok;
    void Start()
    {
        mov = GameObject.Find("karakter").GetComponent<movement>();
        cam = GetComponent<CinemachineVirtualCamera>();
        karakter = GameObject.Find("karakter");
        bakmanok = GameObject.Find("bakmanok");
        cam.Follow = karakter.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.Follow = bakmanok.transform;    
        }
        else
        {
            cam.Follow = karakter.transform;
        }
        
        if (mov.GetComponent<Animator>().GetBool("movement"))
        {
            Vector3 rot = new Vector3(0, 0, zval);
            this.transform.eulerAngles = rot;

            zval += mod;

            if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z <= 10.0f)
            {
                mod = -0.01f;
            }
            if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.01f;
            }
        }
    }

    void lookahead()
    {
        
    }
}