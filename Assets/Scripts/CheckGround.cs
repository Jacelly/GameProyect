using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PLayerControlLv2 player;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PLayerControlLv2>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = col.transform;
            player.grounded = true;
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = collision.transform;
            player.grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
