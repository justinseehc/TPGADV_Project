using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    // change @ inspector!
    public List<GameObject> alphabets = new List<GameObject>();
    public Health health;
    public Word word;


    // only change here!
    private List<string> letter = new List<string>(); // to store individial char for checking
    public List<string> word2Display = new List<string>(); // to store individual char (correct) for displaying ++ created 5 empty index 

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
            word2Display.Add("_");
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
                word2Display[i] = letter[i]; // add correct char to a new list
                letter[i] = ""; // remove char from old list and leave empty

                word.DisplayLetter(word2Display); // send words to display
                break;
            }

            if (i == letter.Count - 1)
            {
                health.LoseHeart(); // loose a heart if loop through all letters
            }
        }

        DestroyLetter(collision.gameObject);
    }

    public void DestroyLetter(GameObject letter)
    {
        Destroy(letter);
    }
}
