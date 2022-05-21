using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

 [CustomEditor(typeof(LevelGenerator))]
public class EditorButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator levelGenerator = (LevelGenerator)target;
        if(GUILayout.Button("Create Labirynth"))
        {
            levelGenerator.GenerateLabirynth();
        }
    }
}
