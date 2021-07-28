using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;

    public static GameManager Instance;

    public StateMachine stateMachine;

    public float timeToSetBallFree = 2f;

    public List<Player> players;

    [Header("Menus")]
    public GameObject uiMainMenu;
  
    private void Awake()
    {
        Instance = this;

    }

    public void SwitchStateReset()
    {
        stateMachine.ResetPosition();

    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeToSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach(var player in players)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }
    public void StartGame()
    {
        ballBase.CanMove(true);
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
    }
    
    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
