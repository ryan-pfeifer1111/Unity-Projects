using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer texture_rend;

    public void drawNoiseMap(float[,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);

        Texture2D t = new Texture2D(width, height);

        List<Color> color_map = new List<Color>();

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                color_map.Add(Color.Lerp(Color.black, Color.white, map[x, y]));
            }
        }
        t.SetPixels(color_map.ToArray());
        t.Apply();

        texture_rend.sharedMaterial.mainTexture = t;
        texture_rend.transform.localScale = new Vector3(width, 1, height);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
