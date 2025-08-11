using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public GameObject platformPrefab;
    public Transform cameraTransform;
    public Letter letter;

    // 1- change @ inspector!
    public int tileBehind = 10; // how many tiles behind (on the left of the camera)?
    public int tileForward = 10; // how many tiles forward (on the right of the camera)?

    // PERCENTAGE TO SPAWN - how often it spawns?
    public float platformChance = 0.1f;
    public float letterChance = 0.1f;

    // HEIGHT - how high should it spawn from other tiles?
    public float platformFloatHeight = 1.0f;
    public float letterFloatHeight = 1.0f;


    // 2 - only change here!
    private int noSpawnZone = 5; // from X = 0, how many tiles to not spawn (platform & letter)?
    private float tileWidth = 1.1f; // what is the size of the tile?
    private float currentTilePosY; // get current tile position Y
    Dictionary<int, GameObject> tiles = new Dictionary<int, GameObject>(); // gameobjects that the script should know?

    void Update()
    {
        int camIndex = Mathf.FloorToInt(cameraTransform.position.x / tileWidth);

        for (int i = -10; i <= camIndex + tileForward; i++)
        {
            if (!tiles.ContainsKey(i))
            {
                // Spawn ground
                Vector2 groundPos = new Vector2(i * tileWidth, 0);
                tiles[i] = Instantiate(groundTilePrefab, groundPos, Quaternion.identity);
                currentTilePosY = groundPos.y;

                // Randomly spawn a platform above
                if (Random.value < platformChance)
                {
                    Vector2 platformPos = new Vector2(i * tileWidth, platformFloatHeight);
                    if (platformPos.x > (tileWidth * noSpawnZone)) // prevent platform from spawning too early
                    {
                        Instantiate(platformPrefab, platformPos, Quaternion.identity);
                        currentTilePosY = platformPos.y;
                    }
                }

                // Spawn letter - using letter script
                if (Random.value < letterChance)
                {
                    Vector2 letterPos = new Vector2(i * tileWidth, currentTilePosY + letterFloatHeight); // coordinates
                    if (letterPos.x > (tileWidth * noSpawnZone) && letterPos.x > cameraTransform.position.x) // prevent letter from spawning too early
                    {
                        GameObject newLetter = Instantiate(letter.LetterGenerator(), letterPos, Quaternion.identity); // cloning of letter
                        newLetter.transform.rotation = Quaternion.Euler(0, 180, 0); // rotation
                        newLetter.transform.localScale = new Vector2(0.5f, 0.5f); // scale
                    }
                }
            }
        }

        // Remove old tiles behind camera
        List<int> toRemove = new List<int>();
        foreach (var index in tiles.Keys)
        {
            if (index < camIndex - tileBehind)
            {
                Destroy(tiles[index]);
                toRemove.Add(index);
            }
        }
        foreach (int i in toRemove)
            tiles.Remove(i);
    }
}

