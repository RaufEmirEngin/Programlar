using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;


    private float dirX = 0f;
    // [SerializeField]  Inspector panelinde de�i�kenleri g�r�n�r k�lmak i�in kullan�lan bir niteliktir.
    // Bu nitelik sayesinde, private veya protected eri�im belirleyicisine sahip olan de�i�kenler,
    // normalde Inspector panelinde g�z�kmezken [SerializeField] kullan�larak g�r�n�r hale getirilebilir.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // enum, karakterin hareket durumlar�n� temsil eder.Her bir durum bir say�sal de�ere sahiptir ve belirli bir durumu ifade eder:
    // idle: Karakter hareketsiz durumda.
    // running: Karakter sa�a veya sola ko�uyor.
    // jumping: Karakter z�pl�yor.
    // falling: Karakter d���yor.
    private enum MovementState {idle ,running, jumping, falling }


    [SerializeField] private AudioSource jumpSoundEffect;
 

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        // Player karakteri i�in GameObject olu�turma ve SpriteRenderer ekleme
        GameObject playerObject = new GameObject("Player");
        SpriteRenderer playerRenderer = playerObject.AddComponent<SpriteRenderer>();
        // Burada sprite'� atamak i�in bir �rnek olarak varsay�lan bir sprite atan�yor
        playerRenderer.sprite = Resources.Load<Sprite>("PlayerSprite"); // �rnek isim, sizinki ile de�i�tirin

        // Arka plan/zemin i�in GameObject olu�turma ve TilemapRenderer ekleme
        GameObject backgroundObject = new GameObject("Background");
        TilemapRenderer backgroundRenderer = backgroundObject.AddComponent<TilemapRenderer>();
        // Burada Tilemap veya TilemapRenderer kullan�m� i�in gereken ayarlamalar yap�lmal�d�r
        // �rnek olarak, TilemapRenderer bile�enine bir Tilemap atamas� yap�labilir

        // Olu�turulan GameObject'leri iste�inize g�re sahneye yerle�tirebiliriz
        // �rne�in, pozisyonlar�n� ayarlamak i�in transform.position kullanabiliriz
        playerObject.transform.position = new Vector3(0f, 0f, 0f); // �rnek pozisyonlar, sizin oyununuz i�in uygun olanlar� kullan�n
        backgroundObject.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        // dirX e�er negatif de�erse sola, dirX>0 ise sa� tarafa gidicek
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
         

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Vector3  3d oyunlarda daha �nemlidir.
            //Atlama komutunu y eksenine g�re 14f dedim. Z�plama oran�n� ayarlad�m.

            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
       // karakterin hareket durumunu belirler ve buna ba�l� olarak animasyonlar�n ge�i�ini sa�lar.
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            // Karakterin flip(d�nme/�evirme) X-Y g�re karakterin kafas� d�ner.
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }


        if (rb.velocity.y > 1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y <-.1f)
        {
            state = MovementState.falling;
        }
        // anim.SetInteger("state",(int)state); ifadesi ise Animator bile�enindeki "state" parametresine
        // state de�i�keninin de�erini atar ve animasyonlar� bu de�ere g�re de�i�tirir.
        anim.SetInteger("state",(int)state);
    }
    // coll.bounds.center: coll ad�ndaki Collider2D nesnesinin merkezi.
    // coll.bounds.size: coll ad�ndaki Collider2D nesnesinin boyutlar�.
    // 0f: Kutunun d�n���.
    // Vector2.down: Kutunun at�laca�� y�nde bir vekt�r (genellikle a�a�� y�ne bir vekt�r).
    // .1f: Kutunun ne kadar mesafe gidece�i (yerde olup olmad���n� anlamak i�in).
    private bool IsGrounded()
    {
        // Coll.bound.center: Merkez noktas�
        // coll.bounds.size: Karakterin �arp��ma kutusun boyutlar�,(Hitbox)
        // 0f: Kutunun d�n�� de�eri,
        // Vector2.down: Kutunun a�a�� y�nde hareket ettirece�i,
        // .1f: Kutunun a�a��ya do�ru ne kadar mesasafe gidece�i 
        // jumpableGround: Bu, bir LayerMask'tir ve hangi layerlar�n "zemin" olarak kabul edilece�ini belirler.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
