using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MobaGame
{
    [CustomEditor(typeof(SkillItem))]
    public class SkillInspector : Editor
    {

        public SerializedProperty skillName;
        public SerializedProperty skillID;
        public SerializedProperty targetType;
        public SerializedProperty isPositive;
        public SerializedProperty coolDownTime;
        public SerializedProperty radius;
        public SerializedProperty castDistance;
        public SerializedProperty castTime;
        public SerializedProperty duration;
        public SerializedProperty cost;

        private void OnEnable()
        {
            skillName = serializedObject.FindProperty("skillName");
            skillID = serializedObject.FindProperty("skillID");
            targetType = serializedObject.FindProperty("targetType");
            isPositive = serializedObject.FindProperty("isPositive");
            coolDownTime = serializedObject.FindProperty("coolDownTime");
            radius = serializedObject.FindProperty("radius");
            castDistance = serializedObject.FindProperty("castDistance");
            castTime = serializedObject.FindProperty("castTime");
            duration = serializedObject.FindProperty("duration");
            cost = serializedObject.FindProperty("cost");

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.indentLevel = 1;
            EditorGUILayout.PropertyField(skillName, new GUIContent("技能名"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(skillID, new GUIContent("技能ID"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(targetType, new GUIContent("目标类型"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(isPositive, new GUIContent("是否正面"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(coolDownTime, new GUIContent("冷却时间"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(radius, new GUIContent("范围半径"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(castDistance, new GUIContent("施法距离"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(castTime, new GUIContent("施法时间"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(duration, new GUIContent("持续时间"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(cost, new GUIContent("魔法消耗"));
            GUILayout.Space(5);



            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}