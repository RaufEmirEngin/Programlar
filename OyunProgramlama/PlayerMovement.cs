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
    // [SerializeField]  Inspector panelinde deðiþkenleri görünür kýlmak için kullanýlan bir niteliktir.
    // Bu nitelik sayesinde, private veya protected eriþim belirleyicisine sahip olan deðiþkenler,
    // normalde Inspector panelinde gözükmezken [SerializeField] kullanýlarak görünür hale getirilebilir.
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    // enum, karakterin hareket durumlarýný temsil eder.Her bir durum bir sayýsal deðere sahiptir ve belirli bir durumu ifade eder:
    // idle: Karakter hareketsiz durumda.
    // running: Karakter saða veya sola koþuyor.
    // jumping: Karakter zýplýyor.
    // falling: Karakter düþüyor.
    private enum MovementState {idle ,running, jumping, falling }


    [SerializeField] private AudioSource jumpSoundEffect;
 

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


        // Player karakteri için GameObject oluþturma ve SpriteRenderer ekleme
        GameObject playerObject = new GameObject("Player");
        SpriteRenderer playerRenderer = playerObject.AddComponent<SpriteRenderer>();
        // Burada sprite'ý atamak için bir örnek olarak varsayýlan bir sprite atanýyor
        playerRenderer.sprite = Resources.Load<Sprite>("PlayerSprite"); // Örnek isim, sizinki ile deðiþtirin

        // Arka plan/zemin için GameObject oluþturma ve TilemapRenderer ekleme
        GameObject backgroundObject = new GameObject("Background");
        TilemapRenderer backgroundRenderer = backgroundObject.AddComponent<TilemapRenderer>();
        // Burada Tilemap veya TilemapRenderer kullanýmý için gereken ayarlamalar yapýlmalýdýr
        // Örnek olarak, TilemapRenderer bileþenine bir Tilemap atamasý yapýlabilir

        // Oluþturulan GameObject'leri isteðinize göre sahneye yerleþtirebiliriz
        // Örneðin, pozisyonlarýný ayarlamak için transform.position kullanabiliriz
        playerObject.transform.position = new Vector3(0f, 0f, 0f); // Örnek pozisyonlar, sizin oyununuz için uygun olanlarý kullanýn
        backgroundObject.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
         dirX = Input.GetAxisRaw("Horizontal");
        // dirX eðer negatif deðerse sola, dirX>0 ise sað tarafa gidicek
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
         

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // Vector3  3d oyunlarda daha önemlidir.
            //Atlama komutunu y eksenine göre 14f dedim. Zýplama oranýný ayarladým.

            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
       // karakterin hareket durumunu belirler ve buna baðlý olarak animasyonlarýn geçiþini saðlar.
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            // Karakterin flip(dönme/çevirme) X-Y göre karakterin kafasý döner.
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
        // anim.SetInteger("state",(int)state); ifadesi ise Animator bileþenindeki "state" parametresine
        // state deðiþkeninin deðerini atar ve animasyonlarý bu deðere göre deðiþtirir.
        anim.SetInteger("state",(int)state);
    }
    // coll.bounds.center: coll adýndaki Collider2D nesnesinin merkezi.
    // coll.bounds.size: coll adýndaki Collider2D nesnesinin boyutlarý.
    // 0f: Kutunun dönüþü.
    // Vector2.down: Kutunun atýlacaðý yönde bir vektör (genellikle aþaðý yöne bir vektör).
    // .1f: Kutunun ne kadar mesafe gideceði (yerde olup olmadýðýný anlamak için).
    private bool IsGrounded()
    {
        // Coll.bound.center: Merkez noktasý
        // coll.bounds.size: Karakterin çarpýþma kutusun boyutlarý,(Hitbox)
        // 0f: Kutunun dönüþ deðeri,
        // Vector2.down: Kutunun aþaðý yönde hareket ettireceði,
        // .1f: Kutunun aþaðýya doðru ne kadar mesasafe gideceði 
        // jumpableGround: Bu, bir LayerMask'tir ve hangi layerlarýn "zemin" olarak kabul edileceðini belirler.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
