using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // change @ inspector!
    public Letter letter;
    public GameOver gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Alphabet")
        {
            letter.CheckLetter(collision);
        }
        else if (collision.gameObject.tag == "Death")
        {
            gameOver.EndTheGame();
        }
    }
}
