using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int map_width;
    public int map_height;
    public float noise_scale;
    public bool auto_update;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offset;

    public void generateMap()
    {
        float[,] map = Noise.generateNosieMap(map_width, map_height, seed, noise_scale, octaves, persistance, lacunarity, offset);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.drawNoiseMap(map);
    }
    void OnValidate()
    {
        if(map_height < 1)
        {
            map_height = 1;
        }
        if(map_width < 1)
        {
            map_width = 1;
        }
        if(lacunarity < 1)
        {
            lacunarity = 1;
        }
        if(octaves < 0)
        {
            octaves = 0;
        }
    }
}
