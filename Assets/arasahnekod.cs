using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arasahnekod : MonoBehaviour
{
    Animator anim;
    public TextMeshProUGUI text;
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetInteger("sahne", anim.GetInteger("sahne") + 1);
        }
        if (anim.GetInteger("sahne") == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        

       
    }
    private void FixedUpdate()
    {
        if (anim.GetInteger("sahne") == 0)
        {
            text.text = "Uzaydan Dunya'ya GiZEMLi bir MAKiNE dusmekte. ";
        }
        if (anim.GetInteger("sahne") == 1)
        {
            text.text = " IssIz bir cole dusen bu makine bir sure yalnIz basIna durdu. ";
        }
        if (anim.GetInteger("sahne") == 2)
        {
            text.text = " OlayI farkeden bilim adamlari hemen makinenin etrafInI cevirdi ve oraya bir arastIrma tesisi kurdular. ";
        }
        if (anim.GetInteger("sahne") == 3)
        {
            text.text = " Bu makinenin neye yaradIgInI kimse bilmiyordu , simdiye kadar. ";
        }
    }
}
