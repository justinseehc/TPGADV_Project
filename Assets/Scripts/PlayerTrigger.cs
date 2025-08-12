using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // 1 - change @ inspector!
    public Letter letter;
    public Scene sceneManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Alphabet")
        {
            letter.CheckLetter(collision);
        }
        else if (collision.gameObject.tag == "Death")
        {
            FindObjectOfType<Scene>().GameOver(true);
        }
    }
}
