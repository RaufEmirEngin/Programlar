using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    // Bu metod, bu yapýþkan platform nesnesi ile bir 2D fiziksel çarpýþma gerçekleþtiðinde çaðrýlýr. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {   

            collision.gameObject.transform.SetParent(transform);
        }
    }
    // Bu metod, iki nesne arasýndaki 2D fiziksel çarpýþma sona erdiðinde çaðrýlýr.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    // Bu metod, bu yapýþkan platform nesnesine baðlý bir 2D tetikleyici (trigger) nesneye giriþ olduðunda çaðrýlýr.
    // Eðer tetikleyiciye giren nesnenin ismi "Player" ise, giren nesnenin transform'unu bu yapýþkan platformun alt nesnesi haline getirir.
    // Yani, Player nesnesi bu yapýþkan platforma yapýþýk hale gelir.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Parent class'a baðlanýr.(StickPlatform.cs)
            collision.gameObject.transform.SetParent(transform);
        }
    }
    // Bu metod, bu yapýþkan platform nesnesine baðlý bir 2D tetikleyici (trigger) nesneden çýkýþ olduðunda çaðrýlýr. 
    // Eðer tetikleyiciden çýkan nesnenin ismi "Player" ise, çýkan nesnenin transform'unun ebeveynini (parent) null olarak ayarlar.
    // Bu, Player nesnesinin bu yapýþkan platformdan ayrýlmasýný saðlar.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Parent class'a baðlanýr.(StickPlatform.cs) Null durumunda da baðýmsýz olur.
            collision.gameObject.transform.SetParent(null);
        }
    }
}
