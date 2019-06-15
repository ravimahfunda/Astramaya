using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviours : MonoBehaviour
{
    public Joystick joystick;
    public Slider ammoBar;

    public AudioSource footstepAudio;
    public AudioSource shootAudio;
    public AudioSource oceanAudio;

    // Attack System
    public Transform bulletSpawnPoint;
    public GameObject arrow;
    public float shootPower;
    public float attackDelay;
    public int maxArrowAmmo;
    private bool allowShoot = true;

    public float movementSpeed;
    public float jumpPower;
    public float jumpLimit;

    bool isGrounded = true;
    int jumpCount = 0;
    bool isFaceRight = true;
    bool isSwim = false;

    float hMove = 0;
    float vMove = 0;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ammoBar.maxValue = maxArrowAmmo;
        ammoBar.value = maxArrowAmmo;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vMove = rb.velocity.y;
        float swimSpeed = movementSpeed * 3 / 4;
        if (isSwim) {
            vMove = joystick.Vertical * swimSpeed;
        }

        if (joystick.Horizontal >= .2f || Input.GetAxis("Horizontal") > 0)
        {
            if (!footstepAudio.isPlaying && isGrounded) footstepAudio.Play();
            if (!isFaceRight) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isFaceRight = true;
            }

            hMove = isSwim ? swimSpeed : movementSpeed;
            animator.SetBool("IsMoving", true);
        }
        else if (joystick.Horizontal <= -.2f || Input.GetAxis("Horizontal") < 0)
        {
            if(!footstepAudio.isPlaying && isGrounded)footstepAudio.Play();
            if (isFaceRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isFaceRight = false;
            }

            hMove = isSwim ? -swimSpeed : -movementSpeed;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            footstepAudio.Stop();
            animator.SetBool("IsMoving", false);
            hMove = 0;
        }

        rb.velocity = new Vector2(hMove, vMove);
    }

    public void Shoot(){
        if (allowShoot && ammoBar.value > 0) {
            ammoBar.value--;
            allowShoot = false;
            shootAudio.Play();
            animator.SetTrigger("Shoot");
            Vector2 shootForce = transform.right * shootPower;

            GameObject gb = Instantiate(arrow, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            if (!isFaceRight) {
                shootForce *= -1;
                gb.transform.localScale = new Vector2(-1f, 1f);
            }
            gb.GetComponent<Rigidbody2D>().AddForce(shootForce, ForceMode2D.Impulse);
            Destroy(gb, 1f);

            StartCoroutine(delayShoot());
        }
    }

    IEnumerator delayShoot() {
        yield return new WaitForSeconds(attackDelay);
        allowShoot = true;
    }

    public void Jump() {
        if (jumpCount < jumpLimit)
        {
            isGrounded = false;
            rb.velocity = Vector2.up * jumpPower;
            jumpCount++;
            animator.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Platform": {
                isGrounded = true;
                jumpCount = 0;
                animator.SetBool("IsJumping", false);
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ocean":
                {
                    rb.gravityScale = .5F;
                    isSwim = true;
                    jumpCount = 0;
                    animator.SetBool("IsSwim", true);
                    break;
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ocean":
                {
                    rb.gravityScale = 1F;
                    isSwim = false;
                    jumpCount = 0;
                    animator.SetBool("IsSwim", false);
                    break;
                }
        }
    }
}
