﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameState { Idle, Playing, Ended,Ready };
public class GameController : MonoBehaviour
{
    [Range(0f,0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage backgroud;
    public RawImage platfrom;
    public GameObject uiIdle;
    public GameObject uiScore;
    public Text pointsText;
    public Text recordText;

    public GameState gameState = GameState.Idle;

    public GameObject player;
    public GameObject enemyGenerator;

    public float scaleTime = 6f;
    public float scaleInc = .25f;

    private int points = 0;

    private AudioSource musicPlayer;
    // Start is called before the first frame update
    void Start()
    {
        recordText.text = "BEST: " + GetMaxScore().ToString();
        musicPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool userAction = Input.GetKeyDown("up") || Input.GetMouseButtonDown(0);
        //start the game
        if (gameState== GameState.Idle && userAction)
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            uiScore.SetActive(true);
            player.SendMessage("UpdateState","PlayerRun");
	        player.SendMessage("UpdateState","PlayerFoxRun");
            player.SendMessage("DustPlay");
            enemyGenerator.SendMessage("StartGenerator");
            InvokeRepeating("GameTimeScale", scaleTime, scaleTime);
            musicPlayer.Play();
        }
        //game going
        else if (gameState == GameState.Playing)
        {
            Parallax();

        }
        //game ready to restart
        else if (gameState == GameState.Ready)
        {
            if(userAction)
            {
                RestarGame();
            }

        }
	    //else if (gameState == GameState.Ended)
        //{
        //    if (userAction)
         //   {
           //     RestarGame();
          //  }

           // Parallax();

        //}
    //CAMBIO DE SCENA
	//if ((points) >= 3){
	 //   enemyGenerator.SendMessage("CancelGenerator",true);
      //   SceneManager.LoadScene("Level2");
       // }

    }
    void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        backgroud.uvRect = new Rect(backgroud.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platfrom.uvRect = new Rect(platfrom.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);

    }
    public void RestarGame()
    {
        ResetTimeScale();
        SceneManager.LoadScene("Level2");
    }
    void GameTimeScale()
    {
        Time.timeScale += scaleInc;
        Debug.Log("Ritmo incrementado: " + Time.timeScale.ToString());
    }
    public void ResetTimeScale(float newTimeScale = 1f)
    {
        CancelInvoke("GameTimeScale");
        Time.timeScale = newTimeScale;
        Debug.Log("Ritmo restablecido: " + Time.timeScale.ToString());
    }
    public void IncreasePoints()
    {
        pointsText.text = (++points).ToString();
        if (points >= GetMaxScore())
        {
            recordText.text = "BEST: " + points.ToString();
            SaveScore(points);
        }
    }
    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("Max Points", 0);
    }
    public void SaveScore(int currentPoints)
    {
        PlayerPrefs.SetInt("Max Points", currentPoints);
    }
}
