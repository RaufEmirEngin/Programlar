using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    // Bu metod, bu yap��kan platform nesnesi ile bir 2D fiziksel �arp��ma ger�ekle�ti�inde �a�r�l�r. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {   

            collision.gameObject.transform.SetParent(transform);
        }
    }
    // Bu metod, iki nesne aras�ndaki 2D fiziksel �arp��ma sona erdi�inde �a�r�l�r.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    // Bu metod, bu yap��kan platform nesnesine ba�l� bir 2D tetikleyici (trigger) nesneye giri� oldu�unda �a�r�l�r.
    // E�er tetikleyiciye giren nesnenin ismi "Player" ise, giren nesnenin transform'unu bu yap��kan platformun alt nesnesi haline getirir.
    // Yani, Player nesnesi bu yap��kan platforma yap���k hale gelir.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Parent class'a ba�lan�r.(StickPlatform.cs)
            collision.gameObject.transform.SetParent(transform);
        }
    }
    // Bu metod, bu yap��kan platform nesnesine ba�l� bir 2D tetikleyici (trigger) nesneden ��k�� oldu�unda �a�r�l�r. 
    // E�er tetikleyiciden ��kan nesnenin ismi "Player" ise, ��kan nesnenin transform'unun ebeveynini (parent) null olarak ayarlar.
    // Bu, Player nesnesinin bu yap��kan platformdan ayr�lmas�n� sa�lar.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Parent class'a ba�lan�r.(StickPlatform.cs) Null durumunda da ba��ms�z olur.
            collision.gameObject.transform.SetParent(null);
        }
    }
}
