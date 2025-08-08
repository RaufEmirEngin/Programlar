using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // GameObject t�r�nde bir dizi. Bu dizi, GameObject'leri temsil eden noktalar� i�erir.
    // Bu noktalar, scriptin takip edece�i yolu olu�turur.
    [SerializeField] private GameObject[] waypoints;
    // �u anda takip edilen waypoint'in dizideki indeksini tutar.
    private int currentWayPointIndex = 0;
    // GameObject'in hareket h�z�n� belirler.
    [SerializeField] private float speed = 2f;
   

    // Update is called once per frame
    private void Update()
    {
        // �u anki konum ile bir sonraki hedef nokta aras�ndaki mesafeyi hesaplar.
        // E�er GameObject hedef noktaya yeterince yak�nsa, bir sonraki hedefe ge�i� yap�l�r.
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= waypoints.Length)
            {
                // E�er mevcut waypoint son waypoint ise, indeks s�f�ra d�nd�r�lerek d�ng�sel bir yol olu�turulur.
                currentWayPointIndex = 0;
            }
        }
        // GameObject'i mevcut konumundan hedef noktaya do�ru belirtilen h�zda hareket ettirir. Bu, as�l hareketi ger�ekle�tiren komuttur.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
    }
}
