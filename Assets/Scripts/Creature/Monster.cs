using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviorDesigner;

namespace MobaGame
{
	
	public class Monster : MonoBehaviour {

		Actor actor;

		void Start () {

			actor = GetComponent<Actor> ();
			//手动控制BehaviorManager的更新
			//前提在BehaviorManager组件Update Interval属性为manual
			//BehaviorDesigner.Runtime.BehaviorManager.instance.Tick();
		}


		void Update () 
		{

		}
	}
}




