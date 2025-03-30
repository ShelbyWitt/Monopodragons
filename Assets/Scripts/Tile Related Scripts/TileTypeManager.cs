// TileTypeManager.cs
using UnityEngine;
using System.Collections.Generic;

public class TileTypeManager : MonoBehaviour
{
    [System.Serializable]
    public struct TileTypeWeight
    {
        public GameObject tilePrefab;
        public float weight;
    }

    public TileTypeWeight[] tileTypes;
    public bool randomizeOnStart = true;

    void Start()
    {
        if (randomizeOnStart)
        {
            RandomizeAllTiles();
        }
    }

    void RandomizeAllTiles()
    {
        float totalWeight = 0;
        foreach (var type in tileTypes)
        {
            totalWeight += type.weight;
        }

        Tiles[] allTiles = FindObjectsByType<Tiles>(FindObjectsSortMode.None);
        foreach (Tiles tile in allTiles)
        {
            Transform tileTypeChild = tile.transform.Find("TileType");
            if (tileTypeChild != null)
            {
                float random = Random.Range(0, totalWeight);
                float currentWeight = 0;

                foreach (var type in tileTypes)
                {
                    currentWeight += type.weight;
                    if (random <= currentWeight)
                    {
                        TileType newTileType = tileTypeChild.gameObject.AddComponent(type.tilePrefab.GetComponent<TileType>().GetType()) as TileType;
                        break;
                    }
                }
            }
        }
    }
}