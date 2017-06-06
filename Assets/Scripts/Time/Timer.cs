using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class Timer :  object {

		public bool bLoop = false;
		public float endTimePos = 0.0F;  //结束时间点
		public float curTimePos;         //当前时间点
		// Use this for initialization
		public System.Action<Hashtable> action;     //回调
		public Hashtable  paramTable;  //参数表
		 
		public Timer()
		{
			
		}

		public void StopTimer()
		{
			curTimePos = endTimePos;
		}

		public void CallBack()
		{
			Debug.Log ("执行Timer回调!");
			if(action != null && curTimePos >= endTimePos)
			{
				action (paramTable);
			}

		}
	}
}

