using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : MonoBehaviour
{
    public Joystick joystick;

    // Attack System
    public Transform bulletSpawnPoint;
    public GameObject arrow;
    public float shootPower;
    public float attackDelay;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (!isFaceRight) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isFaceRight = true;
            }

            hMove = isSwim ? swimSpeed : movementSpeed;
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else if (joystick.Horizontal <= -.2f || Input.GetAxis("Horizontal") < 0)
        {
            if (isFaceRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isFaceRight = false;
            }

            hMove = isSwim ? -swimSpeed : -movementSpeed;
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
            hMove = 0;
        }

        rb.velocity = new Vector2(hMove, vMove);
    }

    public void Shoot(){
        if (allowShoot) {
            allowShoot = false;

            Vector2 shootForce = transform.right * shootPower;

            if (!isFaceRight) {
                shootForce *= -1;
            }

            GameObject gb = Instantiate(arrow, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
            rb.velocity = Vector2.up * jumpPower;
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag) {
            case "Platform": {
                isGrounded = true;
                jumpCount = 0;
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
                    GetComponent<SpriteRenderer>().color = new Color(155,253,255,255);
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
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                    break;
                }
        }
    }
}
