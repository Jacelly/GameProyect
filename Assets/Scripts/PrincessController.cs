﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collisionInfo){
	if(collisionInfo.gameObject.tag == "Player"){
	    Debug.Log("Player Detected!");
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
    }
}