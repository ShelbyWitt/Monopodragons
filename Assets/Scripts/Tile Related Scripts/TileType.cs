// TileType.cs
using UnityEngine;

public abstract class TileType : MonoBehaviour
{
    protected Player player;
    protected Tiles parentTile;
    public Color tileColor;
    private MeshRenderer meshRenderer;

    void Start()
    {
        parentTile = GetComponentInParent<Tiles>();
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
        }
        ApplyTileColor();
    }

    void ApplyTileColor()
    {
        if (meshRenderer != null)
        {
            Material material = new Material(meshRenderer.material);
            material.color = tileColor;
            meshRenderer.material = material;
        }
    }

    public abstract void OnPlayerLand(Player player);
}

