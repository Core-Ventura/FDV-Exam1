using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DogPlayerController : MonoBehaviour
{

    Vector2 velocityX = new Vector2(0, 1);
    Vector2 velocityY = new Vector2(1, 0);
    Rigidbody2D rb;
    SpriteRenderer sr;
    public Animator animator;

    public int life = 100;
    public int bones = 0;
    public UIManager uiManager;

    float curTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.I))
        {
            rb.MovePosition(rb.position + velocityX * Time.fixedDeltaTime);
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.K))
        {
            rb.MovePosition(rb.position + velocityY * Time.fixedDeltaTime);
            sr.flipX = false;
            animator.SetBool("isWalking", true);

        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.M))
        {
            rb.MovePosition(rb.position - velocityX * Time.fixedDeltaTime);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.J))
        {
            rb.MovePosition(rb.position - velocityY * Time.fixedDeltaTime);
            sr.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bones")
        {
            bones += 1;
        }

        if (collision.gameObject.tag == "BigBone")
        {
            bones += 2;
        }

        if (collision.gameObject.tag == "House")
        {
            Win();
        }

        if (collision.gameObject.tag == "Skull")
        {
            life -= 1;
            checkDeath();
        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        //Bones 
        if(collision.gameObject.tag == "Bones" || collision.gameObject.tag == "BigBone")
        {
            animator.SetBool("isHappy", true);
        }


        //Skull
        if (collision.gameObject.tag == "Skulls")
        {
            animator.SetBool("isSad", true);


            //TEST LENTO
            if (curTime <= 0f)
            {
                curTime = 0.15f;
                life -= 1;
                checkDeath();
            }
            else
            {
                curTime -= Time.deltaTime;
            }

            //TEST RAPIDO
            //life -= 1;
            //checkDeath();
        }

        //Waste
        if (collision.gameObject.tag == "Waste")
        {
            animator.SetBool("isSad", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Bones Animation
        if (collision.gameObject.tag == "Bones" || collision.gameObject.tag == "BigBone")
        {
            animator.SetBool("isHappy", false);

        }


        //Skull and Waste Animations
        if (collision.gameObject.tag == "Skulls" || collision.gameObject.tag == "Waste")
        {
            animator.SetBool("isSad", false);
        }
    }


    private void Win()
    {
        uiManager.youWinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Lose()
    {
        uiManager.youWinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void checkDeath()
    {
        if(life <= 0)
        {
            Lose();
        }
    }
}
