using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]private Transform player;
    private void Update()
    {
        // transform.position, kameranýn mevcut konumunu temsil eder.
        // kameranýn x ve y pozisyonlarýný oyuncunun x ve y pozisyonlarýna eþitleyerek, kameranýn oyuncuyu takip etmesini saðlar. 
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
