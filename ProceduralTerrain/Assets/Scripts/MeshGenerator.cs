using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGenerator
{
    public static MeshData generateTerrainMesh(float[,] height_map)
    {
        int width = height_map.GetLength(0);
        int height = height_map.GetLength(1);

        float top_left_x = (width - 1) / -2f;
        float top_left_z = (height - 1) / 2f;

        MeshData mesh_data = new MeshData(width, height);
        int vert_index = 0;

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                mesh_data.vertices[vert_index] = new Vector3(top_left_x + x, height_map[x,y], top_left_z - y);
                mesh_data.uv[vert_index] = new Vector2(x / (float)width, y / (float)height);

                if(x < width - 1 && y < height - 1)
                {
                    //mesh_data.addTriangle(vert_index, vert_index + width + 1, vert_index + width);
                    //mesh_data.addTriangle(vert_index + width + 1, vert_index, vert_index + 1);

                    mesh_data.addTriangle(vert_index + width, vert_index + width + 1, vert_index);
                    mesh_data.addTriangle(vert_index + 1, vert_index, vert_index + width + 1);
                }

                vert_index++;
            }
        }

        return mesh_data;
    }
}

public class MeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uv;

    int tri_index = 0;

    public MeshData(int width, int height)
    {
        vertices = new Vector3[width * height];
        uv = new Vector2[width * height];
        triangles = new int[(width - 1) * (height - 1) * 6];
    }

    public void addTriangle(int v1, int v2, int v3)
    {
        triangles[tri_index] = v1;
        triangles[tri_index + 1] = v2;
        triangles[tri_index + 2] = v3;
        tri_index += 3;
    }

    public Mesh createMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();

        return mesh;
    }
}
