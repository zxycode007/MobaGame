using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;


namespace MobaGame
{
	public class BuffAsset : Editor {

		//创建新技能项目
		[MenuItem("Assets/NewBuff")]
		static void  createNewBuff()
		{
			ScriptableObject buffItem = ScriptableObject.CreateInstance<BuffItem> ();
			if(!buffItem)
			{
				Debug.LogError ("创建新状态配置项失败!");
				return;
			}
			string path = Application.dataPath + "/Resource/Data/Buff/";

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory (path);
			}

			path = String.Format ("Assets/Resource/Data/Buff/{0}.asset", "newBuff");

			AssetDatabase.CreateAsset (buffItem,path);

		}
	}
}

