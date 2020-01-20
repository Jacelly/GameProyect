using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerActionEagle : MonoBehaviour
{
    private AudioSource audioEnemy3;
    public AudioClip jumpClip3;
    public AudioClip LifeClip3;
    public AudioClip dieClip3;
    // Start is called before the first frame update
    void Start()
    {
        audioEnemy3 = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yoffset = 0.71f;
            if (transform.position.y + yoffset > col.transform.position.y )
            {

                col.SendMessage("EagleEnemyKnockBack", transform.position.x);
                //audioEnemy3.clip = dieClip3;
                audioEnemy3.Play();

            }
            else
            {
                col.SendMessage("EnemyJump");
                Destroy(gameObject);

            }

        }
    }
}
