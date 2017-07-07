using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Surface_Creator))]
public class SurfaceCreatorInspector : Editor
{

    private Surface_Creator creator;

    private void OnEnable()
    {
        creator = target as Surface_Creator;
        Undo.undoRedoPerformed += RefreshCreator;
    }

    private void OnDisable()
    {
        Undo.undoRedoPerformed -= RefreshCreator;
    }

    private void RefreshCreator()
    {
        if (Application.isPlaying)
        {
            creator.Refresh();
        }
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        DrawDefaultInspector();
        if (EditorGUI.EndChangeCheck())
        {
            RefreshCreator();
        }
    }
}