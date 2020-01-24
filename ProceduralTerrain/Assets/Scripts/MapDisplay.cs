using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer texture_rend;

    public void drawTexture(Texture2D tex)
    {
        texture_rend.sharedMaterial.mainTexture = tex;
        texture_rend.transform.localScale = new Vector3(tex.width, 1, tex.height);
    }
}
