using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayerControlLv2 : MonoBehaviour
{
    public float speed = 2f;
    public float maxSpeed = 5f;
    public bool grounded;
    public float jumpPower = 6.5f;
    public CircleCollider2D colliderMuerte;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;
    //private int vida = 3;
    private bool Muerto = false;



    //GameController
    private static int vida = 3;
    public string lifeString = "Life";
    public Text TextLife;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        //anim.SetInteger("Vida", vida);

        if (TextLife != null)
        {
            TextLife.text = lifeString + vida.ToString();
        }

        { //Activar el doble salto, al caer(sin haber saltado antes)}
            if (grounded)
            {
                doubleJump = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !Muerto)
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }

        }

        if (Muerto)
        {

            StartCoroutine(Muerte());
        }


    }

    void FixedUpdate()
    {
        if (!Muerto)
        {
            Vector3 fixedVelocity = rb2d.velocity;
            fixedVelocity.x *= 0.75f;

            if (grounded)
            {
                rb2d.velocity = fixedVelocity;
            }

            float h = Input.GetAxis("Horizontal");
            if (!movement) h = 0;

            rb2d.AddForce(Vector2.right * speed * h);

            float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
            rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            { //Cambiar de dirección al jugador
                if (h > 0.1f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }

                if (h < -0.1f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }

            }

            if (jump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                jump = false;
            }
        }


    }
    void OnBecameInvisible()
    {
        SceneManager.LoadScene("Menu");
        //transform.position = new Vector3(-12.98f, -0.74f, 0);
    }
    public void EnemyJump()
    {
        jump = true;
    }
    public void EnemyKnockBack(float enemyPosX)
    {
        vida = vida - 1;

        if (vida <= 0)
        {
            Muerto = true;
            //anim.Play("PlayerLv2_Muerte");
            //rb2d.isKinematic = true;
            //colliderMuerte.isTrigger = true;
            //new WaitForSeconds(1);
            ////SceneManager.LoadScene("SampleScene");
            //rb2d.isKinematic = false;
            //rb2d.velocity = new Vector2(0, 4f);
        }

        else
        {
            jump = true;

            float side = Mathf.Sign(enemyPosX - transform.position.x);
            rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);

            movement = false;
            Invoke("EnableMovement", 0.7f);
            Color color = new Color(255 / 255f, 106 / 255f, 0 / 255f);
            //spr.color = Color.red;
            spr.color = color;
        }

    }

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    public IEnumerator Muerte()
    {
        anim.Play("PlayerLv2_Muerte");
        rb2d.isKinematic = true;
        colliderMuerte.isTrigger = true;
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene("SampleScene");

        //rb2d.isKinematic = false;
        rb2d.velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(0.2f);
    }

}
