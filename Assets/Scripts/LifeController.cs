using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    private AudioSource LifeAudioSource;
    public AudioClip lifeAudio;
    public GameObject LifeAudio2;
    
    // Start is called before the first frame update
    void Start()
    {
        LifeAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //LifeAudioSource.clip = lifeAudio;
            //LifeAudioSource.Play();
            Instantiate(LifeAudio2);
            Destroy(gameObject);
            PLayerControlLv2.vida += 1;
            
        }

    }

}
