using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{

    public static int cherries = 0;


    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Burada ki cherry bizim oluþturduðumuz Tag ile kýyaslanacak.
        if (collision.gameObject.CompareTag("Cherry"))
        {

            collectionSoundEffect.Play();
           
            // Obje(cherry) yok olur.
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries:" + cherries;
        }    
    }


}
