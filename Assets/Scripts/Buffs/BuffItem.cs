using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

namespace MobaGame
{


	[Serializable]
	public class BuffItem : ScriptableObject {

		public int BuffID = 0;
		public string BuffName = "未命名状态";
		public bool isPositive = true;
		public int  count = 0;   //叠加数量
		public bool allowOverlay = true;
		public bool canBeRemoved = true;
		public string iconName = "";   //Buff图标
		public string desc = "";      //描述
		public string effectName = "";   //效果名
		public string partName = "";   //部件名
		public Vector3  effectOffset = Vector3.zero ;
		public Vector3  effectRotation = Vector3.zero;


	}

	
}
