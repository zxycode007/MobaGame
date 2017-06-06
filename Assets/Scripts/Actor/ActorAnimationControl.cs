using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	public class ActorAnimationControl : MonoBehaviour {

		public Actor actor;

		void Start()
		{
			
		}

		void endAttack(string arg)
		{
			Debug.LogWarning (actor.creatureName + "攻击动画播放结束");
			actor.endAttack ();
		}

		void dead(string arg)
		{
			Debug.LogWarning (actor.creatureName + "单位死亡!");
			actor.unitDie ();
		}

		void beginSkillEffect(string arg)
		{
			Debug.LogWarning ("开始技能效果");
			actor.beginSkillEffect ();
		}
	}
}

