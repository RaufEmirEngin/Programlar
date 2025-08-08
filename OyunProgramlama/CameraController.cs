using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]private Transform player;
    private void Update()
    {
        // transform.position, kameran�n mevcut konumunu temsil eder.
        // kameran�n x ve y pozisyonlar�n� oyuncunun x ve y pozisyonlar�na e�itleyerek, kameran�n oyuncuyu takip etmesini sa�lar. 
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
