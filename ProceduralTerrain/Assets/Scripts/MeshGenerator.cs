using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static void generateTerrainMesh(float[,] height_map)
    {
        int width = height_map.GetLength(0);
        int height = height_map.GetLength(1);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {

            }
        }
    }
}

public class MeshData
{
    public struct Triangle
    {
        public int v1;
        public int v2;
        public int v3;
    }

    public Vector3[] vertices;
    public Triangle[] triangles;

    int tri_index = 0;

    public MeshData(int width, int height)
    {
        vertices = new Vector3[width * height];
        triangles = new Triangle[(width - 1) * (height - 1) * 2];
    }

    public void addTriangle(int v1, int v2, int v3)
    {
        Triangle tri = new Triangle();
        tri.v1 = v1;
        tri.v2 = v2;
        tri.v3 = v3;
    }
}
