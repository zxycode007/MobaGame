using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MobaGame
{
	public class TimerManager : GameContext {

		private List<Timer> timerList;
		// Use this for initialization
		void Start () {
			
			timerList = new List<Timer> ();
		}

		public void AddTimer(Timer t)
		{
			timerList.Add (t);
		}

		public Timer createNewTimer(float period, bool isLoop, System.Action<Hashtable> action, Hashtable paramTable)
		{
			Timer t = new Timer ();
			t.action = action;
			t.curTimePos = 0;
			t.endTimePos = period;
			t.paramTable = paramTable;
			return t;
		}

		private static bool  isCompleted(Timer t)
		{
			bool ret = false;
			if(t == null || t.curTimePos >= t.endTimePos)
			{
				ret = true;
			}
			return ret;
		}

		// Update is called once per frame
		void Update () {

			//Debug.Log ("TimerList size" + timerList.Count);
			//更新timer
			foreach (Timer t in timerList)
			{
				t.curTimePos += Time.deltaTime;
				if(t.curTimePos >= t.endTimePos)
				{
					if(t.bLoop)
					{
						t.CallBack ();
						t.curTimePos = 0;
					}else
					{
						t.CallBack ();
					}
				}
			}
			//删除完成的timer
			timerList.RemoveAll (isCompleted);

		}
	}
}

