using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointToPlayer : MonoBehaviour
{
    public Player player;
    public string checkTag = "Ball";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == checkTag)
        {
            Points();
        }
    }

    private void Points()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
