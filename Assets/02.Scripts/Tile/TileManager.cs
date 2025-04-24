using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance { get; private set; }

    Dictionary<Vector2Int, TileChecking> tileMap = new Dictionary<Vector2Int, TileChecking>();
    [SerializeField] Vector2 gridOrigin = new Vector2(-5.55f, -1.5f);
    [SerializeField] float tileSpaceX = 1.6f;
    [SerializeField] float tileSpaceY = 1.0f;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterTile(Vector2Int gridPos, TileChecking tile)
    {
        tileMap[gridPos] = tile;
    }

    public TileChecking GetTileAt(Vector2Int gridPos)
    {
        if(tileMap.TryGetValue(gridPos, out TileChecking tile))
        {
            return tile;
        }
        return null;
    }
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        int x = Mathf.RoundToInt((worldPos.x - gridOrigin.x) / tileSpaceX);
        int y = Mathf.RoundToInt((worldPos.y - gridOrigin.y) / tileSpaceY);
        return new Vector2Int(x, y);
    }
    public Vector3 GridToWorld(Vector2Int gridPos)
    {
        float x = gridOrigin.x + gridPos.x * tileSpaceX;
        float y = gridOrigin.y + gridPos.y * tileSpaceY;
        return new Vector3(x, y, 0);
    }


}
