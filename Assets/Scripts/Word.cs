using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro

public class Word : MonoBehaviour
{
    // change @ inspector!
    public GameObject[] foods;
    public Image image;
    public TextMeshProUGUI text;
    public Letter letter;


    // only change here!
    private string word;


    private void Awake()
    {
        // change image
        int randValue = Random.Range(0, foods.Length);
        image.sprite = foods[randValue].GetComponent<SpriteRenderer>().sprite;

        // change text
        //text.text = foods[randValue].name;
        foreach (char letter in foods[randValue].name)
        {
            text.text += "_";
        }
        letter.StoreLetter(foods[randValue].name);
    }

    public void DisplayLetter(List<string> word2Display)
    { 
        for (int i = 0; i < word2Display.Count; i++)
        {
            Debug.Log(word2Display[i]);
            word += word2Display[i]; // add letter by letter
        }
        text.text = word; // update TMP
        word = ""; // clear any value
    }
}
