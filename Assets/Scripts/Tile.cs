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

    // MANAGER
    public GameObject tileManager;


    // 2 - only change here!
    private int noSpawnZone = 5; // from X = 0, how many tiles to not spawn (platform & letter)?
    private float tileWidth = 1.1f; // what is the size of the tile?
    private float currentTilePosY; // get current tile position Y
    Dictionary<int, GameObject> grounds = new Dictionary<int, GameObject>(); // grounds that the script should know?
    Dictionary<int, GameObject> platforms = new Dictionary<int, GameObject>(); // platforms that the script should know?
    Dictionary<int, GameObject> letters = new Dictionary<int, GameObject>(); // letters that are not collided with player

    void Update()
    {
        int camIndex = Mathf.FloorToInt(cameraTransform.position.x / tileWidth);

        for (int i = -15; i <= camIndex + tileForward; i++)
        {
            if (!grounds.ContainsKey(i))
            {
                // Spawn ground
                Vector2 groundPos = new Vector2(i * tileWidth, 0);
                grounds[i] = Instantiate(groundTilePrefab, groundPos, Quaternion.identity);
                grounds[i].transform.parent = tileManager.transform; // parent
                currentTilePosY = groundPos.y;

                // Randomly spawn a platform above
                if (Random.value < platformChance)
                {
                    Vector2 platformPos = new Vector2(i * tileWidth, platformFloatHeight);
                    if (platformPos.x > (tileWidth * noSpawnZone)) // prevent platform from spawning too early
                    {
                        platforms[i] = Instantiate(platformPrefab, platformPos, Quaternion.identity);
                        platforms[i].transform.parent = tileManager.transform; // parent
                        currentTilePosY = platformPos.y;
                    }
                }

                // Spawn letter - using letter script
                if (Random.value < letterChance)
                {
                    Vector2 letterPos = new Vector2(i * tileWidth, currentTilePosY + letterFloatHeight); // coordinates
                    if (letterPos.x > (tileWidth * noSpawnZone) && letterPos.x > cameraTransform.position.x) // prevent letter from spawning too early
                    {
                        letters[i] = Instantiate(letter.LetterGenerator(), letterPos, Quaternion.identity); // cloning of letter
                        letters[i].transform.rotation = Quaternion.Euler(0, 180, 0); // rotation
                        letters[i].transform.localScale = new Vector2(0.5f, 0.5f); // scale
                        letters[i].transform.parent = tileManager.transform; // parent
                    }
                }
            }
        }

        // Remove old tiles behind camera
        List<int> toRemove = new List<int>();
        foreach (var index in grounds.Keys)
        {
            if (index < camIndex - tileBehind)
            {
                Destroy(grounds[index]);
                toRemove.Add(index);
            }
        }
        foreach (var index in platforms.Keys)
        {
            if (index < camIndex - tileBehind)
            {
                Destroy(platforms[index]);
                toRemove.Add(index);
            }
        }
        foreach (var index in letters.Keys)
        {
            if (index < camIndex - tileBehind)
            {
                Destroy(letters[index]);
                toRemove.Add(index);
            }
        }
        foreach (int i in toRemove)
        {
            grounds.Remove(i);
            platforms.Remove(i);
            letters.Remove(i);
        }

    }
}

