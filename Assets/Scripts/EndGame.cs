using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER!!!");
    }
}
