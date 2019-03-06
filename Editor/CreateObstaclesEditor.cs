using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateObstacles))]
public class CreateObstaclesEditor : Editor
{

    SerializedProperty s_BeatList;
    SerializedProperty s_Obstacle;
    CreateObstacles m_Target;

    private void OnEnable()
    {
        s_BeatList = serializedObject.FindProperty("m_BeatList");
        s_Obstacle = serializedObject.FindProperty("obstacle");
        m_Target = (CreateObstacles)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(s_BeatList);
        EditorGUILayout.PropertyField(s_Obstacle);

        m_Target.createNewParent = EditorGUILayout.Toggle("Create New Parent", m_Target.createNewParent);

        if (m_Target.createNewParent)
        {
            m_Target.newParentName = EditorGUILayout.TextField("New Parent Name", m_Target.newParentName);
            m_Target.newParentLocation = EditorGUILayout.Vector3Field("New Parent Loc", m_Target.newParentLocation);
        }

        if (GUILayout.Button("Create Obstacles"))
        {
            m_Target.CreateBeats();
        }


        serializedObject.ApplyModifiedProperties();
    }

}
