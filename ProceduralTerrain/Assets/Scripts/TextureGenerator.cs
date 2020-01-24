using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D textureFromColorMap(Color[] color_map, int width, int height)
    {
        Texture2D tex = new Texture2D(width, height);
        tex.filterMode = FilterMode.Point;
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.SetPixels(color_map);
        tex.Apply();
        return tex;
    }

    public static Texture2D textureFromHeightMap(float[,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        List<Color> color_map = new List<Color>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                color_map.Add(Color.Lerp(Color.black, Color.white, map[x, y]));
            }
        }

        return textureFromColorMap(color_map.ToArray(), width, height);
    }
}
