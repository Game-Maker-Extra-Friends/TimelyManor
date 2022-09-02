using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Save))]
public class SaveEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Save script = (Save)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Reset"))
        {
            script.Reset();
        }
    }
}
