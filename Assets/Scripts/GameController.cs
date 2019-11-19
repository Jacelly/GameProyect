using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [Range(0f,0.20f)]
    public float parallaxSpeed = 0.02f;
    public RawImage backgroud;
    public RawImage platfrom;
    public GameObject uiIdle;

    public enum GameState { Idle, Playing};
    public GameState gamestate = GameState.Idle;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //start the game
        if(gamestate== GameState.Idle && (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0)))
        {
            gamestate = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState","PlayerRun");
        }
        //game going
        else if (gamestate == GameState.Playing)
        {
            Parallax();

        }
       

    }
    void Parallax()
    {
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        backgroud.uvRect = new Rect(backgroud.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platfrom.uvRect = new Rect(platfrom.uvRect.x + finalSpeed * 4, 0f, 1f, 1f);

    }
}
