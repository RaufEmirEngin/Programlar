using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // GameObject türünde bir dizi. Bu dizi, GameObject'leri temsil eden noktalarý içerir.
    // Bu noktalar, scriptin takip edeceði yolu oluþturur.
    [SerializeField] private GameObject[] waypoints;
    // þu anda takip edilen waypoint'in dizideki indeksini tutar.
    private int currentWayPointIndex = 0;
    // GameObject'in hareket hýzýný belirler.
    [SerializeField] private float speed = 2f;
   

    // Update is called once per frame
    private void Update()
    {
        // Þu anki konum ile bir sonraki hedef nokta arasýndaki mesafeyi hesaplar.
        // Eðer GameObject hedef noktaya yeterince yakýnsa, bir sonraki hedefe geçiþ yapýlýr.
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                // Eðer mevcut waypoint son waypoint ise, indeks sýfýra döndürülerek döngüsel bir yol oluþturulur.
                currentWayPointIndex = 0;
            }
        }
        // GameObject'i mevcut konumundan hedef noktaya doðru belirtilen hýzda hareket ettirir. Bu, asýl hareketi gerçekleþtiren komuttur.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
