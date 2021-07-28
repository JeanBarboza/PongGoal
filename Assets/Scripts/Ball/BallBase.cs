using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    public Vector3 speed = new Vector3(1, 1, 0);
    private Vector3 startSpeed;

    public string checkTag = "Player";

    [Header("Randomization")]
    public Vector2 speedY = new Vector2(1, 3);
    public Vector2 speedX = new Vector2(1, 3);

    private Vector3 _startPosition;
    private bool _canmove = false;

    private void Awake()
    {
        _startPosition = transform.position;
        startSpeed = speed;
    }

    void Update()
    {
        if (!_canmove) return;

        transform.Translate(speed); 
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == checkTag)
            OnPlayerCollision();
        else
            speed.y *= -1;
    }

    public void OnPlayerCollision()
    {
        speed.x *= -1;
        float rand = Random.Range(speedX.x, speedX.y);

        if (speed.x < 0)
            rand = -rand;

        speed.x = rand;

        rand = Random.Range(speedY.x, speedY.y);
        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        _canmove = state;
    }
}
