using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUtilities : MonoBehaviour
{
    public static int GetDistance(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    public static List<Vector2Int> GetTilesInRange(Vector2Int origin, int range)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        for(int dx = -range; dx <= range; dx++)
        {
            for(int dy = -range; dy <= range; dy++)
            {
                Vector2Int offset = new Vector2Int(dx, dy);
                if(Mathf.Abs(dx) + Mathf.Abs(dy) <= range)
                {
                    result.Add(origin + offset);
                }
            }
        }

        return result;

    }
} 
