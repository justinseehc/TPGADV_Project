using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void EndTheGame()
    {
        Debug.Log("GAME OVER!");
        Time.timeScale = 0; // pause game
    }
}
