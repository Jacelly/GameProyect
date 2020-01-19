using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float length;
    private float counter;
    private float startPosition;
    private float actualPosition;
    private float lastPosition;

    private AudioSource audioEnemy3;
    public AudioClip jumpClip3;
    public AudioClip LifeClip3;
    public AudioClip dieClip3;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        audioEnemy3 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime * speed;
        transform.position = new Vector2(Mathf.PingPong(counter,length) + startPosition,transform.position.y);
        actualPosition = transform.position.x;
        if (actualPosition > lastPosition)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (actualPosition < lastPosition)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        lastPosition = transform.position.x;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float yoffset = 0.71f;
            if (transform.position.y + yoffset > col.transform.position.y )
            {

                col.SendMessage("EnemyKnockBack", transform.position.x);
                audioEnemy3.clip = dieClip3;
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
