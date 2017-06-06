using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobaGame
{
	//buff效果类型分为每隔一段时间可执行的动作， 和在自buff添加时启动，buff移除时移除的效果或属性改变
	//buff效果需考虑可以叠加, 不可叠加, 可移除， 不可以移除
	public abstract class BaseBuff  {

		public Actor caster;
		public Actor Owner;
		public float timer;
		public float period;
		public BuffItem attributes;
		 
		 
		// Update is called once per frame
		void Update (float deltaTime) {

			if(timer < period)
			{
				timer += deltaTime;
			}else
			{
				Invoke ();
				timer = 0;
			}
		}


		public abstract void Invoke ();

		public abstract void OnAddBuff ();

		public abstract void OnRemoveBuff ();
		 

	}
}

