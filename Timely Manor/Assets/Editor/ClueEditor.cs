using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Clue))]
public class ClueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Clue script = (Clue)target;

        script.name = EditorGUILayout.TextField("Name", script.name);
        script.icon = (Sprite)EditorGUILayout.ObjectField("Icon", script.icon, typeof(Sprite), false);

        script.presentationMode = (PresentationMode)EditorGUILayout.EnumPopup("Presentation Mode", script.presentationMode);
        GUILayout.Space(10);
        script.description = EditorGUILayout.TextField("Description", script.description);

        switch (script.presentationMode)
        {
            case PresentationMode.Long:
                script.content = EditorGUILayout.TextField("Content", script.content, GUILayout.Height(40));
                break;
            case PresentationMode.Complex:
                script.display = (GameObject)EditorGUILayout.ObjectField("Display", script.display, typeof(GameObject), false);
                break;

        }

        script.location = (Enum.Location)EditorGUILayout.EnumPopup("Location", script.location);
        script.timeline = (Enum.Timeline)EditorGUILayout.EnumPopup("Timeline", script.timeline);

        script.seen = EditorGUILayout.Toggle("Seen", script.seen);

    }
}
