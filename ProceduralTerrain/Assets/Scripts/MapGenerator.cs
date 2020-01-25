using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        NoiseMap,
        ColorMap,
        Mesh
    }

    public DrawMode draw_mode;
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
    public TerrainType[] regions;

    public void generateMap()
    {
        float[,] map = Noise.generateNosieMap(map_width, map_height, seed, noise_scale, octaves, persistance, lacunarity, offset);
        Color[] color_map = new Color[map_width * map_height];

        for(int x = 0; x < map_width; x++)
        {
            for(int y = 0; y < map_height; y++)
            {
                float current_height = map[x, y];
                for(int i = 0; i < regions.Length; i++)
                {
                    if(current_height <= regions[i].height)
                    {
                        color_map[y * map_width + x] = regions[i].color;
                        break;
                    }
                }
            }
        }

        MapDisplay display = FindObjectOfType<MapDisplay>();

        if (draw_mode == DrawMode.NoiseMap)
        {
            display.drawTexture(TextureGenerator.textureFromHeightMap(map));
        }
        else if(draw_mode == DrawMode.ColorMap)
        {
            display.drawTexture(TextureGenerator.textureFromColorMap(color_map, map_width, map_height));
        }
        else if(draw_mode == DrawMode.Mesh)
        {
            display.drawMesh(MeshGenerator.generateTerrainMesh(map), TextureGenerator.textureFromColorMap(color_map, map_width, map_height));
        }
        
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

    [System.Serializable]
    public struct TerrainType
    {
        public string name;
        public float height;
        public Color color;
    }
}
