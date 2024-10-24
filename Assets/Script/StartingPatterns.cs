using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Game of Life/Starting Patterns")]
public class StartingPatterns : ScriptableObject 
{
    public Vector2Int[] cells;

    public Vector2Int GetCenter()
    {
        if(cells == null || cells.Length == 0) return Vector2Int.zero;

        Vector2Int min = Vector2Int.zero;
        Vector2Int max = Vector2Int.zero;

        for(int i = 0; i < cells.Length; i++)
        {
            Vector2Int cell =  cells[i];
            min.x = (int)MathF.Min(cell.x, min.x);
            min.y = (int)MathF.Min(cell.y, min.y);
            max.x = (int)MathF.Max(cell.x, max.x);
            max.y = (int)MathF.Max(cell.y, max.y);
        }

        return (min + max) / 2;
    }
}
