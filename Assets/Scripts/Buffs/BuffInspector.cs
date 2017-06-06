using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace MobaGame
{
	[CustomEditor(typeof(BuffItem))]
	public class BuffInspector : Editor
	{
		public SerializedProperty BuffID;
		public SerializedProperty BuffName;
		public SerializedProperty isPositive;
		public SerializedProperty  count;   //叠加数量
		public SerializedProperty allowOverlay;
		public SerializedProperty canBeRemoved;
		public SerializedProperty iconName;   //Buff图标
		public SerializedProperty desc;      //描述
		public SerializedProperty effectName;      //效果名
		public SerializedProperty partName;      //部件名
		public SerializedProperty effectOffset;      //位置偏移
		public SerializedProperty effectRotation;    //旋转

		private void OnEnable()
		{
			BuffID = serializedObject.FindProperty("BuffID");
			BuffName = serializedObject.FindProperty("BuffName");
			isPositive = serializedObject.FindProperty("isPositive");
			count = serializedObject.FindProperty("count");
			allowOverlay = serializedObject.FindProperty("allowOverlay");
			canBeRemoved = serializedObject.FindProperty("canBeRemoved");
			iconName = serializedObject.FindProperty("iconName");
			desc = serializedObject.FindProperty("desc");
			effectName = serializedObject.FindProperty("effectName");
			partName = serializedObject.FindProperty("partName");
			effectOffset = serializedObject.FindProperty("effectOffset");
			effectRotation = serializedObject.FindProperty("effectRotation");
			 
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUI.indentLevel = 1;
			EditorGUILayout.PropertyField(BuffID, new GUIContent("状态ID"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(BuffName, new GUIContent("状态名"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(isPositive, new GUIContent("正负面"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(count, new GUIContent("层数"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(allowOverlay, new GUIContent("是否叠加"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(canBeRemoved, new GUIContent("是否可移除"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(iconName, new GUIContent("图标名"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(desc, new GUIContent("描述"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(effectName, new GUIContent("效果名"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(partName, new GUIContent("部件名"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(effectOffset, new GUIContent("效果偏移"));
			GUILayout.Space(5);
			EditorGUILayout.PropertyField(effectRotation, new GUIContent("效果旋转"));
			GUILayout.Space(5);


			if (GUI.changed)
			{
				EditorUtility.SetDirty(target);
			}
			serializedObject.ApplyModifiedProperties();
		}


	}
}

