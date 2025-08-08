using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    // change @ inspector!
    public List<GameObject> alphabets = new List<GameObject>();
    public Health health;


    // only change here!
    private List<string> letter = new List<string>();

    // randomized generator for letters
    public GameObject LetterGenerator()
    {
        return alphabets[Random.Range(0, alphabets.Count)];
    }

    // add letter separately into a list
    public void StoreLetter(string Word)
    {
        for (int i = 0; i < Word.Length; i++)
        {
            letter.Add(Word[i].ToString());
        }
    }

    public void CheckLetter(Collider2D collision)
    {
        string[] filteredLetter = collision.gameObject.name.Split('('); // have to split due to the gameobject name - A(Clone)

        // check if the letter is correct
        for (int i = 0; i < letter.Count; i++)
        {
            if (filteredLetter[0] == letter[i])
            {
                Debug.Log("Correct Letter!");
                break;
            }
            if (i == letter.Count - 1)
            {
                health.LoseHeart(); // loose a heart if loop through all letters
            }
        }
    }
}
