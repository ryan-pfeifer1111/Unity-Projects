using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] generateNosieMap(int width, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        System.Random rng = new System.Random(seed);
        Vector2[] octave_offsets = new Vector2[octaves];

        for(int i = 0; i < octaves; i++)
        {
            float offset_x = rng.Next(-100000, 100000) + offset.x;
            float offset_y = rng.Next(-100000, 100000) + offset.y;
            octave_offsets[i] = new Vector2(offset_x, offset_y);
        }

        float[,] noise_map = new float[width,height];

        scale = Mathf.Clamp(scale, 0.0001f, Mathf.Infinity);
        float lowest = float.MaxValue;
        float heighest = float.MinValue;
        float half_width = width / 2f;
        float half_height = height / 2f;

        for(int w = 0; w < width; w++)
        {
            for(int h = 0; h < height; h++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int o = 0; o < octaves; o++)
                {
                    float sample_w = (w - half_width) / scale * frequency + octave_offsets[o].x;
                    float sample_h = (h - half_height) / scale * frequency + octave_offsets[o].y;

                    float perlin_val = Mathf.PerlinNoise(sample_w, sample_h) * 2 - 1;

                    noiseHeight += perlin_val * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight < lowest)
                {
                    lowest = noiseHeight;
                }
                else if(noiseHeight > heighest)
                {
                    heighest = noiseHeight;
                }
                noise_map[w, h] = noiseHeight;
            }
        }

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                noise_map[w, h] = Mathf.InverseLerp(lowest, heighest, noise_map[w, h]);
                Debug.Log("noise_map[" + w + ", " + h + "]: " + noise_map[w, h]);
            }
        }

                return noise_map;
    }
}
