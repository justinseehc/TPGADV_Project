using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // 1 - change @ inspector!
    public GameObject heart;
    public Camera camera;
    public GameOver gameOver;

    // 2 - only change here!
    private int maxHealth = 3;
    private float heartPosX = -10f; // use this for the first heart position x
    private Dictionary<int, GameObject> hearts = new Dictionary<int, GameObject>(); // to store hearts gameobject

    private void Start()
    {
        for (int i = 1; i <= maxHealth; i++)
        {
            Vector2 heartPos = new Vector2(heartPosX, 7.0f); // coordinates
            GameObject newHeart = Instantiate(heart, heartPos, Quaternion.identity); // cloning gameobject
            newHeart.transform.localScale = new Vector2(0.15f, 0.15f); // scale
            newHeart.transform.parent = camera.transform; // parent

            hearts.Add(i, newHeart); // update dictionary
            heartPosX += 1.0f;
        }
    }

    // lose heart when player choose wrong letter
    public void LoseHeart()
    {
        // check if the first heart is used
        if (hearts.Count == 0)
        {
            gameOver.EndTheGame();
        }
        else
        {
            Destroy(hearts[hearts.Count]); // destroy the last heart
            hearts.Remove(hearts.Count);
        }
    }
}
