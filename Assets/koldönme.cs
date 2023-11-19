using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koldönme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 farePozisyonu = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        farePozisyonu.z = 0f; // Karakter 2D olduğu için z eksenini sıfıra ayarla

        // Karakterin pozisyonu ve fare pozisyonu arasındaki yöneyi bul
        Vector3 yon = farePozisyonu - transform.position;

        // Yöneyi kullanarak karakterin rotasyon açısını bul (radyan cinsinden)
        float aci = Mathf.Atan2(yon.y, yon.x) * Mathf.Rad2Deg;

        // -30 ve 10 dereceleri arasında sınırla
        

        // Karakterin rotasyonunu belirtilen açıda ayarla
        transform.rotation = Quaternion.Euler(0f, 0f, aci-180);
    }
}
