using System.Collections;
using System.Collections.Generic;  
using UnityEngine;
using UnityEngine.Windows;

public class HealthSystem : MonoBehaviour
{
    //configuration
    public GameObject heart;
    public int initialHealth = 3;
    public float heartScale = 1f;
    public float heartsStartPosX = -1f;
    public float heartPosGap = 1f;

    //privates
    private int currentHealth;
    private int counter = 1;

    // have the health to load before the game runs
    private void Awake()
    {
        currentHealth = initialHealth; 

        //loop to generate health
        while (counter <= currentHealth)
        {
            GameObject newHeart = Instantiate(heart);
            newHeart.transform.parent = Camera.main.transform; //parent to MainCamera
            newHeart.transform.localPosition = new Vector3(heartsStartPosX + heartPosGap, 4, 10); //position
            newHeart.transform.localScale = new Vector3(heartScale, heartScale, heartScale); //size

            counter++;
            heartsStartPosX += heartPosGap;
        }
    }
}
