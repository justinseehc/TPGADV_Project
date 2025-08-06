using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    public GameObject platformPrefab;
    public Transform cameraTransform;

    // modify tile configuration
    public float tileWidth = 1f; // what is the size of the tile?

    public int tileBehind = 10; // how many tiles behind (on the left of the camera)?
    public int tileForward = 10; // how many tiles forward (on the right of the camera)?

    public float platformChance = 0.3f; // how often does the platform spawn?
    public int platformNoSpawnMaxTiles = 2; // from X = 0, how many tiles away shall the tiles not spawn? (Player Spawn Area Only)
    public float platformFloatingHeight = 2.5f; // how high should the platform spawn?

    int lastTileIndex = 0;
    Dictionary<int, GameObject> tiles = new Dictionary<int, GameObject>();

    void Update()
    {
        int camIndex = Mathf.FloorToInt(cameraTransform.position.x / tileWidth);

        for (int i = camIndex; i <= camIndex + tileForward; i++)
        {
            if (!tiles.ContainsKey(i))
            {
                // Spawn ground
                Vector3 groundPos = new Vector3(i * tileWidth, 0, 0);
                tiles[i] = Instantiate(groundTilePrefab, groundPos, Quaternion.identity);

                // Randomly spawn a platform above
                if (Random.value < platformChance)
                {
                    Vector3 platformPos = new Vector3(i * tileWidth, platformFloatingHeight, 0);
                    if (platformPos.x > (0 + (tileWidth * platformNoSpawnMaxTiles)))
                    {
                        Instantiate(platformPrefab, platformPos, Quaternion.identity);
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

