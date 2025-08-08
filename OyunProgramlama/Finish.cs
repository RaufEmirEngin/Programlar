using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource finishSound;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            //Invoke, belirli bir s�re 2f ( 2 saniye cinsinden) sonra belirtilen metodun �a�r�lmas�n� sa�layan bir fonksiyonudur.
            Invoke("CompleteLevel", 2f); // 2  saniye sonra level complete oluyor.
        }
    }

    // Leveli bitirdikten sonra di�er sahneye(level)ge�iyor.
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}