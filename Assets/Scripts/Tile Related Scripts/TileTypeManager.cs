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
                        // Delete any existing tile type components
                        TileType existingType = tileTypeChild.GetComponent<TileType>();
                        if (existingType != null)
                        {
                            Destroy(existingType);
                        }

                        // Get reference prefab TileType
                        TileType prefabTileType = type.tilePrefab.GetComponent<TileType>();

                        // Create new instance
                        TileType newTileType = tileTypeChild.gameObject.AddComponent(prefabTileType.GetType()) as TileType;

                        // Copy properties from the prefab for damage tiles
                        if (newTileType is DamageTile && prefabTileType is DamageTile)
                        {
                            DamageTile newDamageTile = newTileType as DamageTile;
                            DamageTile prefabDamageTile = prefabTileType as DamageTile;

                            // Copy the damage amount from prefab to new instance
                            newDamageTile.damageAmount = prefabDamageTile.damageAmount;
                            Debug.Log($"Created DamageTile with amount: {newDamageTile.damageAmount}");
                        }

                        break;
                    }
                }
            }
        }
    }
}