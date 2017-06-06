using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MobaGame
{
	[CustomEditor(typeof(CreatureItem))]
	public class CreatureInspector : Editor {

		public SerializedProperty creatureName;
		public SerializedProperty  life;
		public SerializedProperty  maxLife;
		public SerializedProperty  mana;
		public SerializedProperty  maxMana;
		public SerializedProperty  stamina;
		public SerializedProperty  maxStamina;
		public SerializedProperty  level;
		public SerializedProperty  speed;
		public SerializedProperty  attackSpeed;
		public SerializedProperty  attackRange;
		public SerializedProperty  baseAttackDamage;
		public SerializedProperty  strength;             
		public SerializedProperty  intelligence;
		public SerializedProperty  agile;
		public SerializedProperty  armorClass;
		public SerializedProperty  magicResistance;
		public SerializedProperty  elementResistance;
		public SerializedProperty  shadowResistance;
		public SerializedProperty  magicPower;
		public SerializedProperty  spellCastSpeed;
		public SerializedProperty  criticalStrikeRate;
		public SerializedProperty  magicCriticalStrikeRate;
        public SerializedProperty skillIDList;
        public SerializedProperty  type;


		private void OnEnable()
		{
			creatureName = serializedObject.FindProperty ("creatureName");
			life = serializedObject.FindProperty ("life");
			maxLife = serializedObject.FindProperty ("maxLife");
			mana = serializedObject.FindProperty ("mana");
			maxMana = serializedObject.FindProperty ("maxMana");
			stamina = serializedObject.FindProperty ("stamina");
			maxStamina = serializedObject.FindProperty ("maxStamina");
			level = serializedObject.FindProperty ("level");
			speed = serializedObject.FindProperty ("speed");
			attackSpeed = serializedObject.FindProperty ("attackSpeed");
			attackRange = serializedObject.FindProperty ("attackRange");
			baseAttackDamage = serializedObject.FindProperty ("baseAttackDamage");
			strength = serializedObject.FindProperty ("strength");             
			intelligence = serializedObject.FindProperty ("intelligence");
			agile = serializedObject.FindProperty ("agile");
			armorClass = serializedObject.FindProperty ("armorClass");
			magicResistance = serializedObject.FindProperty ("magicResistance");
			elementResistance = serializedObject.FindProperty ("elementResistance");
			shadowResistance = serializedObject.FindProperty ("shadowResistance");
			magicPower = serializedObject.FindProperty ("magicPower");
			spellCastSpeed = serializedObject.FindProperty ("spellCastSpeed");
			criticalStrikeRate = serializedObject.FindProperty ("criticalStrikeRate");
			magicCriticalStrikeRate = serializedObject.FindProperty ("magicCriticalStrikeRate");
            skillIDList = serializedObject.FindProperty("skillIDList");
            type =  serializedObject.FindProperty ("type");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update ();

			EditorGUI.indentLevel = 1;

			EditorGUILayout.PropertyField (creatureName, new GUIContent ("生物名"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (maxLife, new GUIContent ("最大生命值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (life, new GUIContent ("生命值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (maxMana, new GUIContent ("最大魔法值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (mana, new GUIContent ("魔法值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (maxStamina, new GUIContent ("最大精力值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (stamina, new GUIContent ("精力值"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (level, new GUIContent ("等级"));
			GUILayout.Space (5);
            EditorGUILayout.PropertyField(speed, new GUIContent("速度"));
            GUILayout.Space(5);
            EditorGUILayout.PropertyField (attackSpeed, new GUIContent ("攻击速度"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (attackRange, new GUIContent ("攻击范围"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (baseAttackDamage, new GUIContent ("基础攻击伤害"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (armorClass, new GUIContent ("护甲等级"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (strength, new GUIContent ("力量"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (intelligence, new GUIContent ("智力"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (agile, new GUIContent ("敏捷"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (magicResistance, new GUIContent ("魔法抵抗力"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (elementResistance, new GUIContent ("元素抵抗力"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (shadowResistance, new GUIContent ("暗影抵抗力"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (magicPower, new GUIContent ("魔法强度"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (criticalStrikeRate, new GUIContent ("致命一击率"));
			GUILayout.Space (5);
			EditorGUILayout.PropertyField (magicCriticalStrikeRate, new GUIContent ("法术致命一击率"));
			GUILayout.Space (5);
            EditorGUILayout.PropertyField(skillIDList,true);
            GUILayout.Space(5);
            EditorGUILayout.PropertyField(type, new GUIContent("单位类型"));
            GUILayout.Space(5);

            if (GUI.changed)
			{
				EditorUtility.SetDirty (target);	
			}
			serializedObject.ApplyModifiedProperties ();
		}
	}
}

