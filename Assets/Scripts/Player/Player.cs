using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    public float speed = 5;
    public int maxPoints = 3;
    public Image uiPlayer;
    public string playerName;

    [Header("Key Setup")] 
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;


    public Rigidbody2D Rigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }


    void Update()
    {
        if (Input.GetKey(moveUp))
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * speed);
        if (Input.GetKey(moveDown))
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * -speed);
    }

    public void AddPoint()
    {
        currentPoints++;
        CheckMaxPoints();
        UpdateUI();
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }
    private void UpdateUI()
    {
        uiPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints > maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
        }
    }
}
