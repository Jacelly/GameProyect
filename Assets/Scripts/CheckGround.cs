using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PLayerControlLv2 player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PLayerControlLv2>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
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
            player.grounded = false;
        }
    }
}
