using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Animation
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int spriteIndex;
    public float AnimationSpeed = 0.1f;

    // Jump
    public float jumpForce = 3f;
    public float fallSpeed = -15f;
    private Vector3 direction;

    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        InvokeRepeating(nameof(AnimateBird),AnimationSpeed, AnimationSpeed);
    }

    // function otomatis yg dijalankan pertama kali
    private void Update(){
        // getmousebuttondown(0) = klik kiri mouse
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            // jika player klik maka player akan melompat
            direction = Vector3.up * jumpForce;
            SoundManager.instance.PlaySound(jumpSound);
        }
        // jika ada sentuhan lebih dari 0
        if(Input.touchCount > 0){
            // touch objek, 0 adlaah index awal artinya sentuhan paling pertama
            Touch touch = Input.GetTouch(0);
            // jika ada sentuhan yg dimulai
            if(touch.phase == TouchPhase.Began){
                // player akan bergerak keatas
                direction = Vector3.up * jumpForce;
            }
        }

        direction.y += fallSpeed * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    public void AnimateBird()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            GameManager.instance.GameOver();
            SoundManager.instance.PlaySound(gameOverSound);
        }
        if(other.gameObject.tag == "Score")
        {
            GameManager.instance.ScoreUp();
            SoundManager.instance.PlaySound(scoreSound);
        }
    }



}
