using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator))]

public class MapGeneratorEditor : Editor
{
   public override void OnInspectorGUI()
    {
        MapGenerator map_gen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (map_gen.auto_update)
            {
                map_gen.generateMap();
            }
        }

        if(GUILayout.Button("Generate Map"))
        {
            map_gen.generateMap();
        }
    }
}
