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

    private void Awake()
    {
        // change image
        int randValue = Random.Range(0, foods.Length);
        image.sprite = foods[randValue].GetComponent<SpriteRenderer>().sprite;

        // change text
        text.text = foods[randValue].name;
        letter.StoreLetter(foods[randValue].name);
    }
}
