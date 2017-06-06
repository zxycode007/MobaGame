using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace MobaGame
{
	public class CreateAsset : Editor {

		//创建新生物项目
		[MenuItem("Assets/NewCreature")]
		static void  createNewCreature()
		{
			ScriptableObject creature = ScriptableObject.CreateInstance<CreatureItem> ();
			if(!creature)
			{
				Debug.LogError ("创建新生物配置项失败!");
				return;
			}
			string path = Application.dataPath + "/Resource/Data/Creatures/";

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory (path);
			}

			path = String.Format ("Assets/Resource/Data/Creatures/{0}.asset", "newCreature");

			AssetDatabase.CreateAsset (creature,path);

		}



	}
}


