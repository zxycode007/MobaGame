using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

namespace MobaGame
{
	public class SkillAsset : Editor
	{
		//创建新技能项目
		[MenuItem("Assets/NewSkillItem")]
		static void  createNewSkill()
		{
			ScriptableObject skillItem = ScriptableObject.CreateInstance<SkillItem> ();
			if(!skillItem)
			{
				Debug.LogError ("创建新技能配置项失败!");
				return;
			}
			string path = Application.dataPath + "/Resource/Data/Skill/";

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory (path);
			}

			path = String.Format ("Assets/Resource/Data/Skill/{0}.asset", "newSkill");

			AssetDatabase.CreateAsset (skillItem,path);

		}
	}


	


}

