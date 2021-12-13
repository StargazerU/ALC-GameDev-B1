using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int scoreToWin;

    public int curScore;

    public bool gamePaused;
    // Instance of Game Manger

    public static GameManager instance;

    void Awake()
    {
        //Set the instance of this script
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        //freeze game
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle paused menu
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;
        
        //Update Score text
        GameUI.instance.UpdateScoreText(curScore);

        //Have we reachd the score to win?
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        //Set end game screen 
        GameUI.instance.SetEndGameScreen(true,curScore); 
    }

    
}
